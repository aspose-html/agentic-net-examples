// Re‑run validation after HTML modifications to confirm that previously reported issues are resolved.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with an image missing alt attribute (accessibility issue)
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.png'></body></html>";

            // Load document using two-argument constructor (content, baseUri)
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Validate original document
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            var validationResult = validator.Validate(document);

            Console.WriteLine("Validation before modification:");
            PrintValidationResult(validationResult);

            // Modify HTML to add alt attribute
            var imgElements = document.GetElementsByTagName("img");
            if (imgElements.Length > 0)
            {
                var img = (Aspose.Html.HTMLElement)imgElements[0];
                img.SetAttribute("alt", "Sample image");
            }

            // Re-validate after modification
            var validationResultAfter = validator.Validate(document);
            Console.WriteLine("\nValidation after modification:");
            PrintValidationResult(validationResultAfter);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void PrintValidationResult(Aspose.Html.Accessibility.Results.ValidationResult result)
    {
        if (result.Success)
        {
            Console.WriteLine("No accessibility issues found.");
            return;
        }

        foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in result.Details)
        {
            if (!detail.Success)
            {
                Console.WriteLine(detail.Rule.Code + ": " + detail.Rule.Description);
                foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in detail.Errors)
                {
                    Aspose.Html.Accessibility.IError error = techResult.Error;
                    Console.WriteLine("  Error: " + error.ErrorMessage);
                    if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                    {
                        Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                        Console.WriteLine("  Element: " + element.OuterHTML);
                    }
                }
            }
        }
    }
}
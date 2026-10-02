// Re‑run validation after HTML modifications to confirm that previously reported issues are resolved.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content (could be modified as needed)
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Welcome</h1></body></html>";

            // Load HTML content into a document (use two‑argument constructor to avoid file‑not‑found errors)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create WebAccessibility instance and validator for all rules
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Perform validation
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            // Output validation results
            if (!validationResult.Success)
            {
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                {
                    if (!detail.Success)
                    {
                        System.Console.WriteLine(detail.Rule.Code + ": " + detail.Rule.Description);
                        foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in detail.Errors)
                        {
                            Aspose.Html.Accessibility.IError error = techResult.Error;
                            System.Console.WriteLine("Error: " + error.ErrorMessage);
                            if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                            {
                                Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                                System.Console.WriteLine("Element: " + element.OuterHTML);
                            }
                        }
                    }
                }
            }
            else
            {
                System.Console.WriteLine("Validation succeeded. No accessibility issues found.");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
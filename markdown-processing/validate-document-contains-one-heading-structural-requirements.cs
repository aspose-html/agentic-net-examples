// Validate that the document contains at least one heading to meet structural requirements.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Heading</h1><p>Paragraph.</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Validate that the document contains at least one heading element
            var headings = document.GetElementsByTagName("h1");
            bool hasHeading = headings.Length > 0;
            if (!hasHeading)
            {
                Console.WriteLine("Document does not contain any heading elements.");
            }
            else
            {
                Console.WriteLine("Document contains heading elements.");
            }

            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            if (!validationResult.Success)
            {
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                {
                    if (!detail.Success)
                    {
                        Console.WriteLine(detail.Rule.Code + ": " + detail.Rule.Description);
                        foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in detail.Errors)
                        {
                            Aspose.Html.Accessibility.IError error = techResult.Error;
                            Console.WriteLine(error.ErrorMessage);
                            if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                            {
                                Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                                Console.WriteLine(element.OuterHTML);
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Accessibility validation succeeded.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
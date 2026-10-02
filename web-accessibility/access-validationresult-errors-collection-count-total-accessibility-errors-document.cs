// Access ValidationResult.Errors collection to count total accessibility errors found in the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><img src='image.jpg'></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            int totalErrors = 0;
            foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
            {
                if (!ruleResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                    {
                        totalErrors++;
                    }
                }
            }

            Console.WriteLine("Total accessibility errors: " + totalErrors);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Access ValidationResult.Errors collection to count total accessibility errors found in the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with an image missing alt attribute (accessibility error)
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.png'></body></html>";
            // Create HTMLDocument from inline content
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Initialize WebAccessibility and validator
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                // Count total accessibility errors
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
                // Output the result
                System.Console.WriteLine("Total accessibility errors found: " + totalErrors);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
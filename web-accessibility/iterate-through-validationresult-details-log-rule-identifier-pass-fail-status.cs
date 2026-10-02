// Iterate through ValidationResult.Details to log each rule identifier and its pass or fail status.

using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Sample HTML content
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>";

                // Load HTML document from inline content
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

                // Create WebAccessibility and validator
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                // Log overall validation status
                System.Console.WriteLine($"Validation Success: {validationResult.Success}");

                // Iterate through each rule result
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                {
                    string ruleCode = detail.Rule != null ? detail.Rule.Code : "N/A";
                    System.Console.WriteLine($"Rule: {ruleCode}, Passed: {detail.Success}");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
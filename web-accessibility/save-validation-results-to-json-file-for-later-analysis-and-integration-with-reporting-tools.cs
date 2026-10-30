// Save validation results to a JSON file for later analysis and integration with reporting tools.

using System;

namespace AsposeHtmlValidationExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
                {
                    Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                    string json = validationResult.SaveToString();
                    string jsonPath = "validation_results.json";
                    System.IO.File.WriteAllText(jsonPath, json);
                    System.Console.WriteLine($"Validation results saved to {jsonPath}");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
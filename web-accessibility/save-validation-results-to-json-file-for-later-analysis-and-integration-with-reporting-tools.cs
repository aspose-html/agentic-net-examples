// Save validation results to a JSON file for later analysis and integration with reporting tools.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";

            // Load HTML document from inline content
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Create accessibility validator
                Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();

                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                // Save validation result as JSON string
                using (StringWriter sw = new StringWriter())
                {
                    validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.JSON);
                    string jsonContent = sw.ToString();

                    // Write JSON to file
                    string jsonPath = "validation_results.json";
                    File.WriteAllText(jsonPath, jsonContent);

                    Console.WriteLine($"Validation results saved to: {jsonPath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
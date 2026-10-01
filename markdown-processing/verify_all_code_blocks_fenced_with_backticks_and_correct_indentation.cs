// Verify that all code blocks are fenced with backticks and correct any that use indentation.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a minimal HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Initialize WebAccessibility and validator
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator();

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Perform validation
            Aspose.Html.Accessibility.Results.ValidationResult result = validator.Validate(document);

            // Output validation results
            foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in result.Details)
            {
                Console.WriteLine("Rule: {0} - Success: {1}", detail.Rule.Code, detail.Success);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}
// Load HTML content from a string variable into the validator for in‑memory validation scenarios.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

namespace AsposeHtmlValidationExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // HTML content to be validated
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";
                // Base URI required for relative resource resolution
                string baseUri = "http://example.com";

                // Load HTML content into an in‑memory HTMLDocument
                using (HTMLDocument document = new HTMLDocument(htmlContent, baseUri))
                {
                    // Initialize accessibility services
                    WebAccessibility webAccessibility = new WebAccessibility();
                    // Create a validator that includes all available rules
                    AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);
                    // Perform validation
                    ValidationResult validationResult = validator.Validate(document);

                    // Output basic validation information
                    Console.WriteLine($"Validation completed. Total rules checked: {validationResult.Details.Count}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
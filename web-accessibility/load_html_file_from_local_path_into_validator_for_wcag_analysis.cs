// Load an HTML file from a local path into the validator for WCAG analysis.

using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";

            // Initialize WebAccessibility and create a validator for all rules
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load the HTML document from the string literal
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            // Perform validation
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            // Output validation results
            if (validationResult.Success)
            {
                Console.WriteLine("Accessibility validation succeeded. No issues found.");
            }
            else
            {
                Console.WriteLine("Accessibility validation failed. Details:");
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                {
                    Console.WriteLine($"Rule Code: {detail.Rule.Code}");
                    Console.WriteLine($"Description: {detail.Rule.Description}");
                    Console.WriteLine($"Success: {detail.Success}");
                    Console.WriteLine(new string('-', 40));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
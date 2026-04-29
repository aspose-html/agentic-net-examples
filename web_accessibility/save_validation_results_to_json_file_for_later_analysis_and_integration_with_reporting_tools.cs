// Save validation results to a JSON file for later analysis and integration with reporting tools.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the HTML file to be validated
            string htmlPath = "input.html";

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                // Create the accessibility validator
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();

                // Perform validation
                ValidationResult result = validator.Validate(document);

                // Get validation results as a string (default format)
                string validationOutput = result.SaveToString();

                // Save the results to a JSON file (extension only; format may be XML)
                System.IO.File.WriteAllText("validation_results.json", validationOutput);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
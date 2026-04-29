// Save the complete validation report to a string using ValidationResult.SaveToString method for later processing.

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
            string htmlPath = "sample.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create an accessibility validator with default rules
            AccessibilityValidator validator = new WebAccessibility().CreateValidator();

            // Perform validation
            ValidationResult validationResult = validator.Validate(document);

            // Save the validation report to a string
            string report = validationResult.SaveToString();

            // Output the report
            Console.WriteLine(report);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
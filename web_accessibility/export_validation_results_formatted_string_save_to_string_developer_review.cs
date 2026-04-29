// Export validation results as a formatted string using SaveToString for developer review.

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
            // Path to the HTML file to validate
            string htmlPath = "sample.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create an accessibility validator
            AccessibilityValidator validator = new WebAccessibility().CreateValidator();

            // Validate the document
            ValidationResult result = validator.Validate(document);

            // Export validation results to a formatted string
            string validationReport = result.SaveToString();

            // Output the validation report
            Console.WriteLine(validationReport);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
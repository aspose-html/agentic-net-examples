// Redirect console output of validation issues to a log file for persistent storage.

using System;
using System.IO;
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
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                // Create an accessibility validator
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();

                // Perform validation
                ValidationResult validationResult = validator.Validate(document);

                // Get validation details as a string
                string validationReport = validationResult.SaveToString();

                // Write the validation report to a log file
                File.WriteAllText("validation_log.txt", validationReport);
            }
        }
        catch (Exception ex)
        {
            // Log any unexpected errors
            File.WriteAllText("validation_log.txt", $"Error: {ex.Message}");
        }
    }
}
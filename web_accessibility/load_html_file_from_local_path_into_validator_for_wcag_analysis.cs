// Load an HTML file from a local path into the validator for WCAG analysis.

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
            // Initialize the WebAccessibility service
            WebAccessibility webAccessibility = new WebAccessibility();

            // Create a validator that includes all WCAG rules
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            // Path to the local HTML file to be validated
            string htmlPath = "sample.html";

            // Load the HTML document from the specified file path
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Execute the accessibility validation
            ValidationResult validationResult = validator.Validate(document);

            // Output validation results
            if (!validationResult.Success)
            {
                foreach (RuleValidationResult detail in validationResult.Details)
                {
                    // Display each rule's code, description, and whether it passed
                    Console.WriteLine($"Rule: {detail.Rule.Code} - {detail.Rule.Description} - Success: {detail.Success}");
                }
            }
            else
            {
                Console.WriteLine("Document passed all accessibility checks.");
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during loading or validation
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
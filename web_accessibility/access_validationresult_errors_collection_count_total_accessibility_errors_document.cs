// Access ValidationResult.Errors collection to count total accessibility errors found in the document.

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
            // Initialize WebAccessibility service
            WebAccessibility webAccessibility = new WebAccessibility();

            // Create a validator that includes all accessibility rules
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            // Load the HTML document (replace with your file path)
            string htmlPath = "sample.html";
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Perform validation
            ValidationResult validationResult = validator.Validate(document);

            // Count total errors across all failing rules
            int totalErrors = 0;
            if (!validationResult.Success)
            {
                foreach (RuleValidationResult detail in validationResult.Details)
                {
                    if (!detail.Success)
                    {
                        totalErrors += detail.Errors.Count;
                    }
                }
            }

            Console.WriteLine("Total accessibility errors: " + totalErrors);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
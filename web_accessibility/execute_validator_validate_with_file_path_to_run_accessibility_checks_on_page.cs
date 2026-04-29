// Execute validator.Validate with the file path to run accessibility checks on the page.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Path to the HTML file to be validated
            string filePath = args.Length > 0 ? args[0] : "sample.html";

            // Create WebAccessibility instance
            WebAccessibility webAccessibility = new WebAccessibility();

            // Create validator with all validation settings
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(filePath))
            {
                // Perform accessibility validation
                ValidationResult validationResult = validator.Validate(document);

                if (validationResult.Success)
                {
                    Console.WriteLine("Accessibility validation passed.");
                }
                else
                {
                    // Output validation errors
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (ITechniqueResult techResult in ruleResult.Errors)
                            {
                                Console.WriteLine(techResult.Error.ErrorMessage);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
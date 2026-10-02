// Run default accessibility validation and direct console output to a debug logger for development monitoring.

using System;
using System.Diagnostics;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";

            // Initialize accessibility validator
            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            // Load HTML document from inline content
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                ValidationResult validationResult = validator.Validate(document);

                if (validationResult.Success)
                {
                    Debug.WriteLine("Accessibility validation passed.");
                }
                else
                {
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (ITechniqueResult techResult in ruleResult.Errors)
                            {
                                Debug.WriteLine(techResult.Error.ErrorMessage);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}
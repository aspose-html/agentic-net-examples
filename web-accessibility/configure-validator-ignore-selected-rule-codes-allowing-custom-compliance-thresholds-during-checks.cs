// Configure the validator to ignore selected rule codes, allowing custom compliance thresholds during checks.

using System;
using System.Collections.Generic;
using System.IO;
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
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Sample</h1></body></html>";
            // Base URI placeholder
            string baseUri = "about:blank";

            // Initialize WebAccessibility
            WebAccessibility webAccessibility = new WebAccessibility();

            // Create validator with all rules
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            // Load HTML document from inline content
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Perform validation
            ValidationResult validationResult = validator.Validate(document);

            // Define rule codes to ignore
            HashSet<string> ignoredRuleCodes = new HashSet<string>
            {
                "WCAG2AA.Principle1.Guideline1_1.1_1_1", // example code
                "WCAG2AA.Principle2.Guideline2_4.2_4_7"
            };

            // Process validation results, ignoring selected rules
            if (!validationResult.Success)
            {
                foreach (RuleValidationResult detail in validationResult.Details)
                {
                    if (ignoredRuleCodes.Contains(detail.Rule.Code))
                    {
                        // Skip ignored rule
                        continue;
                    }

                    Console.WriteLine($"Rule: {detail.Rule.Code}");
                    Console.WriteLine($"Description: {detail.Rule.Description}");
                    Console.WriteLine($"Success: {detail.Success}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Document passed all validation rules.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
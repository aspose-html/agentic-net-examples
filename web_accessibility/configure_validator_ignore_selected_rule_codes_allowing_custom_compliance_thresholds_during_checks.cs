// Configure the validator to ignore selected rule codes, allowing custom compliance thresholds during checks.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlPath = args.Length > 0 ? args[0] : "sample.html";

            // Initialize WebAccessibility and create a validator with all rules
            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            // Load the HTML document
            using HTMLDocument document = new HTMLDocument(htmlPath);

            // Perform validation
            ValidationResult validationResult = validator.Validate(document);

            // Define rule codes to ignore
            HashSet<string> ignoredRuleCodes = new HashSet<string>
            {
                "WCAG2AA1",
                "WCAG2AA2"
            };

            if (!validationResult.Success)
            {
                foreach (RuleValidationResult detail in validationResult.Details)
                {
                    if (ignoredRuleCodes.Contains(detail.Rule.Code))
                        continue;

                    Console.WriteLine($"Rule: {detail.Rule.Code} - {detail.Rule.Description} | Success: {detail.Success}");
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
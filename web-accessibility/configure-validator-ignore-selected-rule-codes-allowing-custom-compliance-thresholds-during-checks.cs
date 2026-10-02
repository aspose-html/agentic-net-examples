// Configure the validator to ignore selected rule codes, allowing custom compliance thresholds during checks.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";
            // Load HTML document from inline content
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create WebAccessibility instance
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Create validator with all rules
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Define rule codes to ignore
            string[] ignoredRuleCodes = new string[]
            {
                "WCAG2AA.Principle1.Guideline1_1.1_1_1", // example rule code
                "WCAG2AA.Principle2.Guideline2_4.2_4_2"  // another example
            };

            // Perform validation
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            // Process validation results, skipping ignored rules
            if (!validationResult.Success)
            {
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                {
                    if (Array.IndexOf(ignoredRuleCodes, detail.Rule.Code) >= 0)
                    {
                        // Skip ignored rule
                        continue;
                    }

                    Console.WriteLine($"Rule Code: {detail.Rule.Code}");
                    Console.WriteLine($"Description: {detail.Rule.Description}");
                    Console.WriteLine($"Success: {detail.Success}");
                    Console.WriteLine(new string('-', 40));
                }
            }
            else
            {
                Console.WriteLine("Document passed all validation checks (excluding ignored rules).");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
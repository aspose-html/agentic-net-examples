// Use the validator within a unit test to assert that no multimedia accessibility issues exist in sample HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file for validation
            const string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>");
            }

            // Initialize WebAccessibility
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Example 1: Validate against a specific guideline
            // (Principle and guideline identifiers are illustrative; replace with real IDs as needed)
            var principle = webAccessibility.Rules.GetPrinciple("WCAG2AA");
            var guideline = principle.GetGuideline("1.1.1");
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(guideline, Aspose.Html.Accessibility.ValidationBuilder.All);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (validationResult.Success)
                {
                    Console.WriteLine("Document passed the specific guideline validation.");
                }
                else
                {
                    Console.WriteLine("Document failed the specific guideline validation. Details:");
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                Console.WriteLine("- " + techResult.Error.ErrorMessage);
                            }
                        }
                    }
                }
            }

            // Example 2: Validate using all default rules (no specific guideline)
            Aspose.Html.Accessibility.AccessibilityValidator allRulesValidator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = allRulesValidator.Validate(document);

                if (validationResult.Success)
                {
                    Console.WriteLine("Document passed the all‑rules validation.");
                }
                else
                {
                    Console.WriteLine("Document failed the all‑rules validation. Details:");
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                Console.WriteLine("- " + techResult.Error.ErrorMessage);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
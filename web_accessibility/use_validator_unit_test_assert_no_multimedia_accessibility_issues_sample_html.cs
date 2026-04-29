// Use the validator within a unit test to assert that no multimedia accessibility issues exist in sample HTML.

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
            // Initialize WebAccessibility
            WebAccessibility webAccessibility = new WebAccessibility();

            // Retrieve the multimedia guideline (Principle 1.2, Guideline 1.2)
            var guideline = webAccessibility.Rules.GetPrinciple("1.2").GetGuideline("1.2");

            // Create a validator that checks all rules
            AccessibilityValidator validator = webAccessibility.CreateValidator(guideline, ValidationBuilder.All);

            // Load the sample HTML document (replace with actual path or URL)
            using (HTMLDocument document = new HTMLDocument("sample.html"))
            {
                // Perform validation
                ValidationResult validationResult = validator.Validate(document);

                // Assert that no multimedia accessibility issues exist
                if (validationResult.Success)
                {
                    Console.WriteLine("No multimedia accessibility issues found.");
                }
                else
                {
                    Console.WriteLine("Multimedia accessibility issues detected:");
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
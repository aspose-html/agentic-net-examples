// Use the validator in a GitHub Actions workflow to automatically fail builds when caption issues are detected.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

namespace AccessibilityValidatorApp
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                string htmlPath = args.Length > 0 ? args[0] : "index.html";

                // Initialize WebAccessibility and create a validator with all rules
                WebAccessibility webAccessibility = new WebAccessibility();
                AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

                // Load the HTML document
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Perform validation
                    ValidationResult validationResult = validator.Validate(document);

                    // If validation fails, output errors and exit with non-zero code
                    if (!validationResult.Success)
                    {
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
                        return 1; // Indicate failure for CI workflow
                    }

                    Console.WriteLine("Accessibility validation passed.");
                    return 0; // Success
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return 1;
            }
        }
    }
}
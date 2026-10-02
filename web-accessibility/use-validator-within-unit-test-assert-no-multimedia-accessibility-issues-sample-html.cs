// Use the validator within a unit test to assert that no multimedia accessibility issues exist in sample HTML.

using System;

namespace AccessibilityValidatorExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Sample HTML content with multimedia and proper accessibility attributes
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><video src=\"sample.mp4\" controls><track kind=\"captions\" src=\"captions.vtt\" srclang=\"en\" label=\"English\" default></track></video></body></html>";

                // Create WebAccessibility instance
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

                // Create validator for all rules
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                // Load HTML document from inline content
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
                {
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                    if (validationResult.Success)
                    {
                        Console.WriteLine("Accessibility validation passed. No multimedia issues found.");
                    }
                    else
                    {
                        Console.WriteLine("Accessibility validation failed. Issues:");
                        foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                        {
                            if (!ruleResult.Success)
                            {
                                foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
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
}
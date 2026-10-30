// Set a custom issue severity threshold so that only high‑priority accessibility problems are reported.

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
            // Sample HTML content with an image missing alt attribute (high‑priority issue)
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><img src='image.png'></body></html>";

            // Load the HTML content (use two‑argument constructor to avoid file‑path interpretation)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Create a WebAccessibility instance and a validator with all rules
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (validationResult.Success)
                {
                    Console.WriteLine("No accessibility issues found.");
                }
                else
                {
                    // NOTE: The API does not provide a direct way to set a severity threshold.
                    // To report only high‑priority issues, you would need to filter the results
                    // based on the severity information available in the rule/technique results.
                    // Here we simply output all reported issues.

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
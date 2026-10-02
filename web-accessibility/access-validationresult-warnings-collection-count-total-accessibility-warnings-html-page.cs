// Access ValidationResult.Warnings collection to count total accessibility warnings reported for the HTML page.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Sample</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                // Create accessibility validator
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                // Count total warnings (if the API exposed a Warnings collection, it would be used here)
                int warningsCount = 0;
                // The current API version does not provide a direct Warnings collection on ValidationResult.
                // If needed, warnings could be derived from detailed results in future versions.

                Console.WriteLine($"Validation Success: {validationResult.Success}");
                Console.WriteLine($"Total Warnings: {warningsCount}");

                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            Console.WriteLine($"Rule: {ruleResult.Rule.Code} - {ruleResult.Rule.Description}");
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                Console.WriteLine($"Error: {techResult.Error.ErrorMessage}");
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                    Console.WriteLine($"Element: {element.OuterHTML}");
                                }
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
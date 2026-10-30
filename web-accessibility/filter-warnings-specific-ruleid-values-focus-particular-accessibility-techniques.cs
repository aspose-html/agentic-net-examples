// Filter warnings by specific RuleId values to focus on particular accessibility techniques.

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
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.png'></body></html>";

            // Initialize accessibility validator
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load HTML document from inline content
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (!validationResult.Success)
                {
                    // Define Rule IDs to filter
                    HashSet<string> targetRuleIds = new HashSet<string>(new string[] { "R1", "R2" });

                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success && targetRuleIds.Contains(ruleResult.Rule.Code))
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Console.WriteLine(techResult.Error.ErrorMessage);
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No accessibility issues found.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
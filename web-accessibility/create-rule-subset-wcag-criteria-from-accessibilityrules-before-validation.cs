// Create a custom rule subset by selecting specific WCAG criteria from AccessibilityRules before validation.

using System;
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
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Welcome</h1></body></html>";

            // Initialize WebAccessibility
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Select a specific WCAG criterion (example: Perceivable principle, Guideline 1.1, Criterion 1.1.1)
            var principle = webAccessibility.Rules.GetPrinciple("Perceivable");
            var guideline = principle?.GetGuideline("1.1");
            var criterion = guideline?.GetCriterion("1.1.1");

            if (criterion != null)
            {
                Console.WriteLine("{0}:{1} - {2}", criterion.Code, criterion.Description, criterion.Level);
                foreach (IRule technique in criterion.SufficientTechniques)
                {
                    Console.WriteLine("{0}:{1}", technique.Code, technique.Description);
                }
            }
            else
            {
                Console.WriteLine("Specified criterion not found. Proceeding with full validation.");
            }

            // Create validator (using all rules for demonstration)
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load HTML document from string (using two-argument constructor)
            using (var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Perform validation
                ValidationResult validationResult = validator.Validate(document);

                if (validationResult.Success)
                {
                    Console.WriteLine("Accessibility validation succeeded. No issues found.");
                }
                else
                {
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Console.WriteLine(techResult.Error.ErrorMessage);
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
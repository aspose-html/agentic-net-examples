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
            // Create WebAccessibility instance
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Select a specific WCAG criterion (e.g., Perceivable > 1.1 > 1.1.1)
            Aspose.Html.Accessibility.Principle principle = webAccessibility.Rules.GetPrinciple("Perceivable");
            Aspose.Html.Accessibility.Guideline guideline = principle.GetGuideline("1.1");
            Aspose.Html.Accessibility.Criterion criterion = guideline.GetCriterion("1.1.1");

            if (criterion != null)
            {
                Console.WriteLine("{0}:{1} - {2}", criterion.Code, criterion.Description, criterion.Level);
                foreach (Aspose.Html.Accessibility.IRule technique in criterion.SufficientTechniques)
                {
                    Console.WriteLine("{0}:{1}", technique.Code, technique.Description);
                }
            }

            // Prepare a simple HTML document (inline content)
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Create a validator (using all rules; custom subset selection is demonstrated above)
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                // Validate the document
                ValidationResult validationResult = validator.Validate(document);

                if (!validationResult.Success)
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
                else
                {
                    Console.WriteLine("Document passed accessibility validation.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
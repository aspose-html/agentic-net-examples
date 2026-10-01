// Create a custom rule subset by selecting specific WCAG criteria from AccessibilityRules before validation.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            File.WriteAllText(inputPath, htmlContent);

            // Create WebAccessibility instance
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Create validator with all rules
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load the document and validate
            using (var document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
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
                    Console.WriteLine("Document passed accessibility validation.");
                }
            }

            // Retrieve a specific principle, guideline, and criterion
            // Example codes are illustrative; replace with actual codes as needed
            string principleCode = "Principle1";
            string guidelineCode = "Guideline1";
            string criterionCode = "Criterion1";

            Aspose.Html.Accessibility.Principle principle = webAccessibility.Rules.GetPrinciple(principleCode);
            if (principle != null)
            {
                Aspose.Html.Accessibility.Guideline guideline = principle.GetGuideline(guidelineCode);
                if (guideline != null)
                {
                    Aspose.Html.Accessibility.Criterion criterion = guideline.GetCriterion(criterionCode);
                    if (criterion != null)
                    {
                        Console.WriteLine("{0}:{1} - {2}", criterion.Code, criterion.Description, criterion.Level);
                        foreach (Aspose.Html.Accessibility.IRule technique in criterion.SufficientTechniques)
                        {
                            Console.WriteLine("{0}:{1}", technique.Code, technique.Description);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Criterion not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Guideline not found.");
                }
            }
            else
            {
                Console.WriteLine("Principle not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
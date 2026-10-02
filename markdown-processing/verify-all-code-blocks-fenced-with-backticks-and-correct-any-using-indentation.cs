// Verify that all code blocks are fenced with backticks and correct any that use indentation.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure security (allow scripts)
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Load the document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Initialize accessibility validator
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator();

                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult result = validator.Validate(document);

                // Output validation details
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in result.Details)
                {
                    Console.WriteLine("Rule: {0}, Success: {1}", detail.Rule.Code, detail.Success);
                }

                // Example: retrieve specific principle, guideline, and criterion
                Aspose.Html.Accessibility.Principle principle = webAccessibility.Rules.GetPrinciple("1.1");
                if (principle != null)
                {
                    Aspose.Html.Accessibility.Guideline guideline = principle.GetGuideline("1.1.1");
                    if (guideline != null)
                    {
                        Aspose.Html.Accessibility.Criterion criterion = guideline.GetCriterion("1.1.1.1");
                        if (criterion != null)
                        {
                            Console.WriteLine("{0}:{1} - {2}", criterion.Code, criterion.Description, criterion.Level);
                            foreach (Aspose.Html.Accessibility.IRule technique in criterion.SufficientTechniques)
                            {
                                Console.WriteLine("{0}:{1}", technique.Code, technique.Description);
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
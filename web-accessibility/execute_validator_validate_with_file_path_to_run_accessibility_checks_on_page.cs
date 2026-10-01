// Execute validator.Validate with the file path to run accessibility checks on the page.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file for validation
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Validate the document against all accessibility rules
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (var document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                var validationResult = validator.Validate(document);
                if (validationResult.Success)
                {
                    Console.WriteLine("Document passed all accessibility checks.");
                }
                else
                {
                    foreach (var ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (var techResult in ruleResult.Errors)
                            {
                                Console.WriteLine(techResult.Error.ErrorMessage);
                            }
                        }
                    }
                }
            }

            // Validate the document against a specific guideline (example: WCAG 2.0 Guideline 1.1.1)
            var principle = webAccessibility.Rules.GetPrinciple("WCAG2.0");
            var guideline = principle.GetGuideline("1.1.1");
            var validator2 = webAccessibility.CreateValidator(guideline, Aspose.Html.Accessibility.ValidationBuilder.All);
            using (var document2 = new Aspose.Html.HTMLDocument(htmlPath))
            {
                var validationResult2 = validator2.Validate(document2);
                if (!validationResult2.Success)
                {
                    Console.WriteLine("Specific guideline validation errors:");
                    foreach (var ruleResult in validationResult2.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (var techResult in ruleResult.Errors)
                            {
                                Console.WriteLine(techResult.Error.ErrorMessage);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Specific guideline passed.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
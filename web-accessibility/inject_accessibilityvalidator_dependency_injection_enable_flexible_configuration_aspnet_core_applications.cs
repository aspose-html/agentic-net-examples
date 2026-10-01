// Inject AccessibilityValidator via dependency injection to enable flexible configuration in ASP.NET Core applications.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file for validation
            string htmlFilePath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(htmlFilePath, "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>");

            // First validation: all rules, print success or all error messages
            Aspose.Html.Accessibility.WebAccessibility webAccessibility1 = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator1 = webAccessibility1.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(htmlFilePath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult1 = validator1.Validate(document1);
                if (validationResult1.Success)
                {
                    Console.WriteLine("Document passed all accessibility checks.");
                }
                else
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult1.Details)
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

            // Second validation: print only errors targeting HTML elements
            Aspose.Html.Accessibility.WebAccessibility webAccessibility2 = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator2 = webAccessibility2.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(htmlFilePath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult2 = validator2.Validate(document2);
                if (!validationResult2.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult2.Details)
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
            }

            // Clean up temporary file
            if (File.Exists(htmlFilePath))
            {
                File.Delete(htmlFilePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
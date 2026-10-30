// Use the validator in an Azure DevOps pipeline task to publish a validation report as a build artifact.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";

            // Load HTML document from inline content
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Create accessibility validator with all rules
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                // Prepare XML report
                using (StringWriter sw = new StringWriter(new StringBuilder()))
                {
                    validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                    string reportXml = sw.ToString();

                    // Write report to file (simulating Azure DevOps artifact)
                    string reportPath = "validation_report.xml";
                    File.WriteAllText(reportPath, reportXml, Encoding.UTF8);

                    Console.WriteLine($"Validation report saved to: {Path.GetFullPath(reportPath)}");

                    // Optionally output details to console
                    if (!validationResult.Success)
                    {
                        Console.WriteLine("Accessibility issues found:");
                        foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                        {
                            Console.WriteLine($"- Rule: {detail.Rule.Code}");
                            Console.WriteLine($"  Description: {detail.Rule.Description}");
                            Console.WriteLine($"  Success: {detail.Success}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No accessibility issues detected.");
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
// Log all validation messages to a file for further analysis and troubleshooting by developers.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                string logPath = "validation_log.txt";
                using (StreamWriter writer = new StreamWriter(logPath, true))
                {
                    writer.WriteLine("Validation Results - " + DateTime.Now);
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                    {
                        writer.WriteLine(detail.ToString());
                    }
                    writer.WriteLine(new string('-', 40));
                }
            }
            Console.WriteLine("Validation completed. Log written to validation_log.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
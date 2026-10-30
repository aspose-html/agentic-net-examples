// Log all validation messages to a file for further analysis and troubleshooting by developers.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
            string baseUri = "about:blank";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
            {
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator();
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                string logPath = "validation_log.txt";
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(logPath, false))
                {
                    writer.WriteLine("Validation Success: " + validationResult.Success);
                    writer.WriteLine(new string('=', 40));
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                    {
                        writer.WriteLine(detail.ToString());
                        writer.WriteLine(new string('-', 40));
                    }
                }

                System.Console.WriteLine("Validation completed. Log written to " + logPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
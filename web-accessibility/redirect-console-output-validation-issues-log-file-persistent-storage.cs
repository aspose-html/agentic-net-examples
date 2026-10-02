// Redirect console output of validation issues to a log file for persistent storage.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main(string[] args)
    {
        string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
        string logPath = "validation_log.txt";

        try
        {
            using (StreamWriter logWriter = new StreamWriter(logPath, false))
            {
                logWriter.AutoFlush = true;
                TextWriter originalOut = Console.Out;
                Console.SetOut(logWriter);

                using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
                {
                    AccessibilityValidator validator = new WebAccessibility().CreateValidator();
                    ValidationResult result = validator.Validate(document);

                    foreach (RuleValidationResult detail in result.Details)
                    {
                        Console.WriteLine(detail.ToString());
                    }
                }

                Console.SetOut(originalOut);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}
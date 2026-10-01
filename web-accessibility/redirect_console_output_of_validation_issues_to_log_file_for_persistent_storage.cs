// Redirect console output of validation issues to a log file for persistent storage.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
            string resultString = validationResult.SaveToString();

            string logPath = "validation_log.txt";
            File.WriteAllText(logPath, resultString);

            Console.WriteLine("Validation completed. Results written to " + logPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}
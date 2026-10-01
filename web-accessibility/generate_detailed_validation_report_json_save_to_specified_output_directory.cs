// Generate a detailed validation report in JSON format and save it to a specified output directory.

using System;
using System.IO;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string inputHtmlPath = "sample.html";
            string outputDirectory = "output";
            string jsonReportPath = Path.Combine(outputDirectory, "validation_report.json");

            Directory.CreateDirectory(outputDirectory);

            // Ensure a minimal sample HTML file exists
            if (!File.Exists(inputHtmlPath))
            {
                File.WriteAllText(inputHtmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>");
            }

            using (HTMLDocument document = new HTMLDocument(inputHtmlPath))
            {
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();
                ValidationResult validationResult = validator.Validate(document);

                using (StringWriter sw = new StringWriter())
                {
                    validationResult.SaveTo(sw, ValidationResultSaveFormat.XML);
                    string xmlReport = sw.ToString();

                    var reportObject = new
                    {
                        success = validationResult.Success,
                        xml = xmlReport
                    };

                    string json = JsonSerializer.Serialize(reportObject, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(jsonReportPath, json);
                }
            }

            Console.WriteLine("Validation report saved to: " + jsonReportPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
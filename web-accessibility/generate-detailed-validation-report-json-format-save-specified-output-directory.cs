// Generate a detailed validation report in JSON format and save it to a specified output directory.

using System;
using System.IO;
using System.Security;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDirectory = "Output";
            Directory.CreateDirectory(outputDirectory);

            string inputHtmlPath = "sample.html";
            if (!File.Exists(inputHtmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>";
                File.WriteAllText(inputHtmlPath, sampleHtml);
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath))
            {
                Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                string xmlReport = validationResult.SaveToString();
                string escapedXml = SecurityElement.Escape(xmlReport);
                string jsonReport = $"{{\"validationReport\": \"{escapedXml}\"}}";

                string jsonPath = Path.Combine(outputDirectory, "validationReport.json");
                File.WriteAllText(jsonPath, jsonReport);
            }

            Console.WriteLine("Validation report saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
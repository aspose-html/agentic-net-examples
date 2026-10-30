// Generate a detailed validation report in JSON format and save it to a specified output directory.

using System;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define paths
            string inputHtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "input.html");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "output");
            string jsonReportPath = Path.Combine(outputDirectory, "validation_report.json");

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputHtmlPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>";
                File.WriteAllText(inputHtmlPath, sampleHtml);
            }

            // Load HTML document
            using (HTMLDocument document = new HTMLDocument(inputHtmlPath))
            {
                // Create validator
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();

                // Perform validation
                ValidationResult validationResult = validator.Validate(document);

                // Get XML representation of the result
                string xmlReport = validationResult.SaveToString();

                // Convert XML to JSON (simple wrapper)
                var jsonObject = new { xmlReport = xmlReport };
                string jsonContent = JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });

                // Save JSON report
                File.WriteAllText(jsonReportPath, jsonContent);
            }

            Console.WriteLine("Validation report saved to: " + jsonReportPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
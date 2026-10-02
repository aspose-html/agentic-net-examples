// Run batch validation on all HTML files in a project folder and produce a consolidated JSON report.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "HTMLFiles";
            string outputJsonPath = "validation_report.json";

            // Ensure input folder exists
            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                // Create a minimal sample HTML file
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>");
            }

            // Prepare validator
            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            // Collect results
            List<object> report = new List<object>();

            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html", SearchOption.AllDirectories);
            foreach (string filePath in htmlFiles)
            {
                using (HTMLDocument document = new HTMLDocument(filePath))
                {
                    ValidationResult validationResult = validator.Validate(document);
                    string xmlResult = validationResult.ToString();

                    report.Add(new
                    {
                        File = filePath,
                        ValidationXml = xmlResult
                    });
                }
            }

            // Serialize to JSON
            string json = JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(outputJsonPath, json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}
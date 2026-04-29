// Run batch validation on all HTML files in a project folder and produce a consolidated JSON report.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

namespace BatchHtmlValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Folder containing HTML files to validate
                string inputFolder = @"C:\Project\HtmlFiles";
                // Path for the consolidated JSON report
                string reportPath = @"C:\Project\ValidationReport.json";

                // Create the WebAccessibility instance and the validator (rule: create validator)
                WebAccessibility webAccessibility = new WebAccessibility();
                AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

                // Collect validation results
                List<FileValidationResult> results = new List<FileValidationResult>();

                // Get all HTML files in the folder (rule: avoid long-running watcher, use one-shot scan)
                string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html", SearchOption.AllDirectories);

                foreach (string filePath in htmlFiles)
                {
                    // Load the HTML document
                    using (HTMLDocument document = new HTMLDocument(filePath))
                    {
                        // Validate the document
                        ValidationResult validationResult = validator.Validate(document);

                        // Prepare result entry
                        FileValidationResult entry = new FileValidationResult
                        {
                            FilePath = filePath,
                            Success = validationResult.Success,
                            // Convert the validation details to a string (XML) for reference
                            Details = validationResult.SaveToString()
                        };

                        results.Add(entry);
                    }
                }

                // Serialize the results to JSON
                string jsonReport = JsonSerializer.Serialize(results, new JsonSerializerOptions { WriteIndented = true });

                // Write the JSON report to the output file
                File.WriteAllText(reportPath, jsonReport);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Helper class to hold per‑file validation data
    class FileValidationResult
    {
        public string FilePath { get; set; }
        public bool Success { get; set; }
        public string Details { get; set; }
    }
}
// Run batch validation on all HTML files in a project folder and produce a consolidated JSON report.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "HTMLFiles";
            string outputFolder = "ValidationReport";
            string jsonReportPath = Path.Combine(outputFolder, "report.json");

            Directory.CreateDirectory(outputFolder);

            var report = new List<ValidationInfo>();

            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
            foreach (string filePath in htmlFiles)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(filePath))
                {
                    Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                    Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
                    ValidationResult validationResult = validator.Validate(document);

                    var info = new ValidationInfo
                    {
                        FilePath = filePath,
                        Success = validationResult.Success,
                        Errors = new List<string>()
                    };

                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        foreach (IError error in ruleResult.Errors)
                        {
                            info.Errors.Add(error.ErrorMessage);
                        }
                    }

                    report.Add(info);
                }
            }

            string json = JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonReportPath, json);

            Console.WriteLine($"Validation completed. Report saved to: {jsonReportPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    class ValidationInfo
    {
        public string FilePath { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
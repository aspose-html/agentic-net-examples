// Generate a summary report that aggregates total errors across all processed HTML documents in a batch.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            // Define input directory containing HTML files
            string inputDir = "InputHtml";
            // Ensure the directory exists
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                // Create sample HTML files
                File.WriteAllText(Path.Combine(inputDir, "sample1.html"), "<!DOCTYPE html><html><head><title>Sample 1</title></head><body><h1>Test</h1></body></html>");
                File.WriteAllText(Path.Combine(inputDir, "sample2.html"), "<!DOCTYPE html><html><head><title>Sample 2</title></head><body><img src=\"missing.png\" alt=\"Missing Image\"></body></html>");
            }

            int totalErrorCount = 0;
            // Process each HTML file in the directory
            foreach (string htmlPath in Directory.GetFiles(inputDir, "*.html"))
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Create a validator with default rule set
                    WebAccessibility webAcc = new WebAccessibility();
                    var validator = webAcc.CreateValidator();
                    ValidationResult validationResult = validator.Validate(document);

                    // Aggregate errors from each rule result
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (ruleResult.Errors != null)
                        {
                            totalErrorCount += ruleResult.Errors.Count;
                        }
                    }
                }
            }

            Console.WriteLine($"Total validation errors across all processed HTML documents: {totalErrorCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Apply a cancellation token to the validation process to allow graceful termination during long batch runs.

using System;
using System.IO;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            // Define input folder and ensure it exists
            string inputFolder = "input";
            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);

            // Create a minimal sample HTML file if none exist
            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
            if (htmlFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>");
                htmlFiles = new string[] { samplePath };
            }

            // Cancellation token that triggers after 30 seconds
            using (CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(30)))
            {
                CancellationToken token = cts.Token;

                // Create validator (default rule set)
                ValidationResult result;
                var validator = new WebAccessibility().CreateValidator();

                foreach (string filePath in htmlFiles)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Validation cancelled.");
                        break;
                    }

                    using (HTMLDocument document = new HTMLDocument(filePath))
                    {
                        result = validator.Validate(document);
                        Console.WriteLine($"File: {Path.GetFileName(filePath)} - Success: {result.Success}");
                        // Optionally, iterate details
                        foreach (var ruleResult in result.Details)
                        {
                            Console.WriteLine($"  Rule: {ruleResult.Rule.Code} - Passed: {ruleResult.Success}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
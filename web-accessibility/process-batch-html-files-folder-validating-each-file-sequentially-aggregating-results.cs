// Process a batch of HTML files in a folder, validating each file sequentially and aggregating results.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputHtml";
            Directory.CreateDirectory(inputFolder);

            // Create a sample HTML file if the folder is empty
            if (Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello</h1></body></html>");
            }

            int totalFiles = 0;
            int successCount = 0;
            List<string> errorMessages = new List<string>();

            // Create validator
            WebAccessibility webAccessibility = new WebAccessibility();
            var validator = webAccessibility.CreateValidator();

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                totalFiles++;
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    ValidationResult result = validator.Validate(document);
                    if (result.Success)
                    {
                        successCount++;
                    }
                    else
                    {
                        foreach (RuleValidationResult rule in result.Details)
                        {
                            foreach (IError error in rule.Errors)
                            {
                                errorMessages.Add($"{htmlPath}: {error.ErrorMessage}");
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Processed {totalFiles} file(s). Successful: {successCount}. Failed: {totalFiles - successCount}.");

            if (errorMessages.Count > 0)
            {
                Console.WriteLine("Validation errors:");
                foreach (string msg in errorMessages)
                {
                    Console.WriteLine(msg);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Create a PowerShell script that loads the .NET library, validates an HTML file, and prints JSON results.

using System;
using System.IO;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>");
            }

            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);
            HTMLDocument document = new HTMLDocument(inputPath);
            ValidationResult validationResult = validator.Validate(document);

            int failedCount = 0;
            foreach (RuleValidationResult detail in validationResult.Details)
            {
                if (!detail.Success)
                {
                    failedCount++;
                }
            }

            var resultObj = new
            {
                Success = validationResult.Success,
                FailedRules = failedCount
            };

            string json = JsonSerializer.Serialize(resultObj);
            Console.WriteLine(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
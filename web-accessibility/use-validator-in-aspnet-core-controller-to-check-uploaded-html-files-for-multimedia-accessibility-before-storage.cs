// Use the validator in an ASP.NET Core controller to check uploaded HTML files for multimedia accessibility before storage.

using System;
using System.IO;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a sample HTML file with multimedia content
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, @"<!DOCTYPE html><html><head><title>Test</title></head><body><video src=""sample.mp4""></video></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Initialize accessibility validator for multimedia guidelines
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.Guideline guideline = webAccessibility.Rules.GetPrinciple("Multimedia").GetGuideline("AudioVideo");
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(guideline, Aspose.Html.Accessibility.ValidationBuilder.All);

            // Perform validation
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            // Output validation results
            if (validationResult.Success)
            {
                Console.WriteLine("Validation succeeded. No accessibility issues found.");
            }
            else
            {
                Console.WriteLine("Validation failed. Issues:");
                foreach (var ruleResult in validationResult.Details)
                {
                    Console.WriteLine($"- Rule: {ruleResult.Rule.Code} - {ruleResult.Rule.Description}");
                    foreach (var technique in ruleResult.Errors)
                    {
                        Console.WriteLine($"  * Error: {technique.Error.ErrorMessage}");
                    }
                    foreach (var technique in ruleResult.Warnings)
                    {
                        Console.WriteLine($"  * Warning: {technique.Error.ErrorMessage}");
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
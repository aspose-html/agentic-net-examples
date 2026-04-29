// Create a PowerShell script that loads the .NET library, validates an HTML file, and prints JSON results.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input HTML file path (provide as first argument or replace with a literal)
            string htmlPath = args.Length > 0 ? args[0] : "sample.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create WebAccessibility and validator with all rules
            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            // Perform validation
            ValidationResult validationResult = validator.Validate(document);

            // Prepare result object for JSON serialization
            var result = new
            {
                Success = validationResult.Success,
                FailedRules = GetFailedRules(validationResult)
            };

            // Output JSON to console
            string json = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Extract failing rule details from ValidationResult
    private static List<object> GetFailedRules(ValidationResult validationResult)
    {
        var list = new List<object>();
        foreach (RuleValidationResult detail in validationResult.Details)
        {
            if (!detail.Success)
            {
                var errors = new List<string>();
                foreach (var error in detail.Errors)
                {
                    errors.Add(error.ToString());
                }

                list.Add(new
                {
                    Code = detail.Rule?.Code,
                    Description = detail.Rule?.Description,
                    Errors = errors
                });
            }
        }
        return list;
    }
}
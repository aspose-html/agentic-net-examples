// Serialize the ValidationResult to JSON using custom serialization for external tool integration.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            var details = new List<object>();
            foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
            {
                details.Add(new
                {
                    RuleCode = detail.Rule.Code,
                    RuleDescription = detail.Rule.Description,
                    Success = detail.Success
                });
            }

            var resultObject = new
            {
                Success = validationResult.Success,
                Details = details
            };

            string json = JsonSerializer.Serialize(resultObject, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
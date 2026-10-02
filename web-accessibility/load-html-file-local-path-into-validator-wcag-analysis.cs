// Load an HTML file from a local path into the validator for WCAG analysis.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            if (!validationResult.Success)
            {
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                {
                    Console.WriteLine($"Rule Code: {detail.Rule.Code}");
                    Console.WriteLine($"Description: {detail.Rule.Description}");
                    Console.WriteLine($"Success: {detail.Success}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Document passed all accessibility checks.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
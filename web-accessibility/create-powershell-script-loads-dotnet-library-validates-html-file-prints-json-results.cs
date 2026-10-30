// Create a PowerShell script that loads the .NET library, validates an HTML file, and prints JSON results.

using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string inputDir = "Input";
            Directory.CreateDirectory(inputDir);
            string htmlPath = Path.Combine(inputDir, "sample.html");
            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Create accessibility validator
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load document and validate
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                var resultObject = new
                {
                    Success = validationResult.Success,
                    DetailsCount = validationResult.Details != null ? validationResult.Details.Count : 0
                };

                string json = JsonSerializer.Serialize(resultObject, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine(json);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Iterate through ValidationResult.Details to log each rule identifier and its pass or fail status.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";

            // Create a temporary HTML file
            string tempPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempPath, html);

            // Initialize WebAccessibility and validator
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(tempPath);

            // Perform validation
            var validationResult = validator.Validate(document);

            // Output results
            if (!validationResult.Success)
            {
                Console.WriteLine("Accessibility validation failed. Details:");
                foreach (var detail in validationResult.Details)
                {
                    Console.WriteLine($"Rule Code: {detail.Rule.Code}");
                    Console.WriteLine($"Description: {detail.Rule.Description}");
                    Console.WriteLine($"Success: {detail.Success}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Accessibility validation succeeded.");
            }

            // Clean up
            document.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Retrieve the ValidationResult returned by Validate and store it for further processing.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal HTML file for validation
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>");
            }

            // Initialize accessibility validator
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load the document and perform validation
            using (var document = new Aspose.Html.HTMLDocument(inputPath))
            {
                var validationResult = validator.Validate(document);

                if (!validationResult.Success)
                {
                    Console.WriteLine("Validation failed. Details:");
                    foreach (var detail in validationResult.Details)
                    {
                        Console.WriteLine($"Rule: {detail.Rule.Code} - {detail.Rule.Description}, Success: {detail.Success}");
                    }

                    // Save validation result to XML string
                    using (var sw = new StringWriter())
                    {
                        validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                        Console.WriteLine("Validation result XML:");
                        Console.WriteLine(sw.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Validation succeeded.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
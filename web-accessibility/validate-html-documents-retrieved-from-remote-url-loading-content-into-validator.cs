// Validate HTML documents retrieved from a remote URL by loading the URL content into the validator.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // List of URLs to validate
            List<string> urls = new List<string> { "https://example.com", "https://www.w3.org/TR/WCAG20/" };

            // Create output directory
            string outputDir = "ValidationResults";
            Directory.CreateDirectory(outputDir);

            // Initialize accessibility validator with all rules
            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            int index = 1;
            foreach (string url in urls)
            {
                using (HTMLDocument document = new HTMLDocument(url))
                {
                    ValidationResult validationResult = validator.Validate(document);

                    // Save validation result to XML file
                    string outputPath = Path.Combine(outputDir, $"validation_result_{index}.xml");
                    File.WriteAllText(outputPath, validationResult.ToString());

                    // Print errors to console if validation failed
                    if (!validationResult.Success)
                    {
                        Console.WriteLine($"Validation failed for URL: {url}");
                        foreach (RuleValidationResult detail in validationResult.Details)
                        {
                            Console.WriteLine($"Rule: {detail.Rule.Code} - {detail.Rule.Description}");
                            Console.WriteLine($"Success: {detail.Success}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Validation succeeded for URL: {url}");
                    }
                }
                index++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
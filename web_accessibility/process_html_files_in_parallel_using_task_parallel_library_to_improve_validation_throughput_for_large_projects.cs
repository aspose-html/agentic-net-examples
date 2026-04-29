// Process HTML files in parallel using Task Parallel Library to improve validation throughput for large projects.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

namespace HtmlValidationParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input folder containing HTML files
                string inputFolder = @"C:\HtmlFiles";

                // Get all HTML files in the folder
                string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");

                // Process each file in parallel
                Parallel.ForEach(htmlFiles, htmlPath =>
                {
                    // Load the HTML document
                    using (HTMLDocument document = new HTMLDocument(htmlPath))
                    {
                        // Create WebAccessibility instance and validator with all rules
                        WebAccessibility webAccessibility = new WebAccessibility();
                        AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

                        // Perform validation
                        ValidationResult validationResult = validator.Validate(document);

                        // Output validation results
                        if (!validationResult.Success)
                        {
                            foreach (RuleValidationResult detail in validationResult.Details)
                            {
                                Console.WriteLine($"{htmlPath}: Rule {detail.Rule.Code} - {detail.Rule.Description} Success: {detail.Success}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{htmlPath}: Validation passed.");
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
// Validate HTML documents retrieved from a remote URL by loading the URL content into the validator.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Ensure a sample HTML file exists
            string sampleHtmlPath = "sample.html";
            if (!File.Exists(sampleHtmlPath))
            {
                File.WriteAllText(sampleHtmlPath,
                    "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>");
            }

            // Load document from file and display its outer HTML
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sampleHtmlPath))
            {
                string html = document.DocumentElement.OuterHTML;
                Console.WriteLine("Document outer HTML:");
                Console.WriteLine(html);
            }

            // Create WebAccessibility instance
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Retrieve a specific guideline (example: WCAG2AA principle, 1.1.1 guideline)
            Aspose.Html.Accessibility.Guideline guideline = webAccessibility.Rules
                .GetPrinciple("WCAG2AA")
                .GetGuideline("1.1.1");

            // Create a validator for the specific guideline
            Aspose.Html.Accessibility.AccessibilityValidator guidelineValidator =
                webAccessibility.CreateValidator(guideline, Aspose.Html.Accessibility.ValidationBuilder.All);

            // Validate the sample document against the specific guideline
            using (Aspose.Html.HTMLDocument docForGuideline = new Aspose.Html.HTMLDocument(sampleHtmlPath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = guidelineValidator.Validate(docForGuideline);
                if (!validationResult.Success)
                {
                    Console.WriteLine("Guideline validation errors:");
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                    {
                        Console.WriteLine($"Rule: {detail.Rule.Code} - {detail.Rule.Description} - Success: {detail.Success}");
                    }
                }
                else
                {
                    Console.WriteLine("Document passed the specific guideline validation.");
                }
            }

            // Validate multiple documents (using the same file for demonstration)
            System.Collections.Generic.List<string> urls = new System.Collections.Generic.List<string>
            {
                sampleHtmlPath,
                sampleHtmlPath
            };

            string outputDir = "validation_results";
            System.IO.Directory.CreateDirectory(outputDir);

            // Create a validator for all guidelines
            Aspose.Html.Accessibility.AccessibilityValidator allValidator =
                webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            int index = 1;
            foreach (string url in urls)
            {
                using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(url))
                {
                    Aspose.Html.Accessibility.Results.ValidationResult result = allValidator.Validate(doc);
                    string outputPath = System.IO.Path.Combine(outputDir, $"validation_result_{index}.xml");

                    // Save validation result as XML
                    using (System.IO.StringWriter sw = new System.IO.StringWriter())
                    {
                        result.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                        System.IO.File.WriteAllText(outputPath, sw.ToString());
                    }
                }
                index++;
            }

            Console.WriteLine($"Validation results saved to directory: {outputDir}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Generate a summary report that aggregates total errors across all processed HTML documents in a batch.

using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = @"C:\HtmlBatch";
            int totalErrorCount = 0;

            foreach (string htmlPath in Directory.GetFiles(inputDir, "*.html"))
            {
                // Load HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Set up accessibility validator
                WebAccessibility webAccessibility = new WebAccessibility();
                AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

                // Perform validation
                ValidationResult validationResult = validator.Validate(document);

                // Count failing rule details as errors
                int fileErrorCount = validationResult.Details.Count(detail => !detail.Success);
                totalErrorCount += fileErrorCount;

                document.Dispose();
            }

            Console.WriteLine($"Total accessibility errors across all documents: {totalErrorCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
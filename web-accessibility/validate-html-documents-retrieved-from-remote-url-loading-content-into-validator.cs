// Validate HTML documents retrieved from a remote URL by loading the URL content into the validator.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

public class Program
{
    public static void Main()
    {
        try
        {
            List<string> urls = new List<string> { "https://example.com", "https://www.w3.org/TR/WCAG20/" };
            string outputDir = "ValidationResults";
            Directory.CreateDirectory(outputDir);

            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            int index = 1;
            foreach (string url in urls)
            {
                using (HTMLDocument document = new HTMLDocument(url))
                {
                    ValidationResult validationResult = validator.Validate(document);
                    string outputPath = Path.Combine(outputDir, $"validation_result_{index}.xml");
                    File.WriteAllText(outputPath, validationResult.ToString());
                }
                index++;
            }

            Console.WriteLine("Validation completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}
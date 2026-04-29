// Fetch HTML content from a list of URLs, validate each page, and save results as XML files.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            List<string> urls = new List<string> { "https://example.com", "https://example.org" };
            Directory.CreateDirectory("ValidationResults");
            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);
            int index = 1;
            foreach (string url in urls)
            {
                using (HTMLDocument document = new HTMLDocument(url))
                {
                    ValidationResult validationResult = validator.Validate(document);
                    string outputPath = Path.Combine("ValidationResults", $"validation_result_{index}.xml");
                    File.WriteAllText(outputPath, validationResult.ToString());
                }
                index++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
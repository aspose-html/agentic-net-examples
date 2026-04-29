// Log all validation messages to a file for further analysis and troubleshooting by developers.

using System;
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
            string htmlPath = "input.html";
            string logPath = "validation.log";

            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                WebAccessibility webAccessibility = new WebAccessibility();
                AccessibilityValidator validator = webAccessibility.CreateValidator();
                ValidationResult result = validator.Validate(document);

                using (StreamWriter writer = new StreamWriter(logPath, true))
                {
                    writer.WriteLine($"Validation Success: {result.Success}");
                    foreach (RuleValidationResult detail in result.Details)
                    {
                        writer.WriteLine($"Rule Code: {detail.Rule.Code}");
                        writer.WriteLine($"Description: {detail.Rule.Description}");
                        writer.WriteLine($"Success: {detail.Success}");
                        writer.WriteLine(new string('-', 40));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
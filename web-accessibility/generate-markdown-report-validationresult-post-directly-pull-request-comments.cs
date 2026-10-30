// Generate a markdown report from ValidationResult to post directly in pull‑request comments.

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";

            // Load HTML document from string (using a dummy base URI)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Create accessibility validator
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                // Build markdown report
                StringBuilder markdown = new StringBuilder();
                markdown.AppendLine("## Accessibility Validation Report");
                markdown.AppendLine();

                if (validationResult.Success)
                {
                    markdown.AppendLine("All accessibility checks passed.");
                }
                else
                {
                    markdown.AppendLine("The following issues were found:");
                    markdown.AppendLine();

                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                    {
                        markdown.AppendLine($"- **Rule**: `{detail.Rule.Code}` - {detail.Rule.Description} - **Result**: {(detail.Success ? "Passed" : "Failed")}");
                        if (!detail.Success && detail.Errors != null && detail.Errors.Count > 0)
                        {
                            markdown.AppendLine("  - Errors:");
                            foreach (Aspose.Html.Accessibility.IError error in detail.Errors)
                            {
                                markdown.AppendLine($"    - {error.ErrorMessage}");
                            }
                        }
                    }
                }

                // Output markdown to console
                Console.WriteLine(markdown.ToString());

                // Save markdown to file
                string outputPath = "validation_report.md";
                File.WriteAllText(outputPath, markdown.ToString());
                Console.WriteLine($"Markdown report saved to: {Path.GetFullPath(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}
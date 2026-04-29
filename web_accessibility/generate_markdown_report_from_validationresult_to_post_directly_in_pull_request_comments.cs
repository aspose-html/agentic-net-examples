// Generate a markdown report from ValidationResult to post directly in pull‑request comments.

using System;
using System.IO;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string reportPath = "validation_report.md";

            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);
            HTMLDocument document = new HTMLDocument(htmlPath);
            ValidationResult validationResult = validator.Validate(document);

            var markdown = new System.Text.StringBuilder();
            markdown.AppendLine("# Accessibility Validation Report");
            markdown.AppendLine();

            if (validationResult.Success)
            {
                markdown.AppendLine("All accessibility checks passed.");
            }
            else
            {
                foreach (RuleValidationResult detail in validationResult.Details)
                {
                    markdown.Append("- **")
                            .Append(detail.Rule.Code)
                            .Append("**: ")
                            .Append(detail.Rule.Description)
                            .Append(" - ")
                            .Append(detail.Success ? "Passed" : "Failed")
                            .AppendLine();
                }
            }

            File.WriteAllText(reportPath, markdown.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
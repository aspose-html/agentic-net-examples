// Generate a markdown report from ValidationResult to post directly in pull‑request comments.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("# Accessibility Validation Report");
                sb.AppendLine();
                sb.AppendLine("| Rule Code | Description | Success |");
                sb.AppendLine("|-----------|-------------|---------|");

                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                    {
                        string code = detail.Rule != null ? detail.Rule.Code : "";
                        string description = detail.Rule != null ? detail.Rule.Description : "";
                        string success = detail.Success ? "✅" : "❌";
                        sb.AppendLine($"| {code} | {description} | {success} |");
                    }
                }
                else
                {
                    sb.AppendLine("| - | All rules passed | ✅ |");
                }

                string markdown = sb.ToString();
                string outputPath = "validation_report.md";
                System.IO.File.WriteAllText(outputPath, markdown);
                System.Console.WriteLine("Markdown report saved to " + outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}
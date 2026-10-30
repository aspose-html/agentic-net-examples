// Write the formatted validation string to a text file for archival and reporting.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator();
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
            string validationString = validationResult.SaveToString();
            string outputPath = "validation_report.xml";
            System.IO.File.WriteAllText(outputPath, validationString);
            System.Console.WriteLine($"Validation report saved to {outputPath}");
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Generate a detailed validation report in JSON format and save it to a specified output directory.

using System;
using System.IO;
using System.Text.Json;
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
            string outputDirectory = "output";
            Directory.CreateDirectory(outputDirectory);
            string reportPath = Path.Combine(outputDirectory, "validationReport.json");

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
            string xmlReport = validationResult.SaveToString();

            string json = JsonSerializer.Serialize(new { validationReport = xmlReport });
            File.WriteAllText(reportPath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
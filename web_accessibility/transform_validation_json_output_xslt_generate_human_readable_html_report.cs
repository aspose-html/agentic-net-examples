// Transform validation JSON output using XSLT to generate a human‑readable HTML report.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the HTML template, JSON validation data, and the output HTML report
            string templatePath = "template.html";
            string jsonPath = "validation.json";
            string outputPath = "report.html";

            // Load JSON data for the template
            TemplateData templateData = new TemplateData(jsonPath);

            // Default loading options
            TemplateLoadOptions loadOptions = new TemplateLoadOptions();

            // Generate the HTML report by applying the JSON data to the template
            Converter.ConvertTemplate(templatePath, templateData, loadOptions, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
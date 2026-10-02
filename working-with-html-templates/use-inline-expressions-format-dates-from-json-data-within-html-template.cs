// Use inline expressions to format dates from JSON data within the HTML template.

using System;
using System.IO;
using System.Text;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string templatePath = "template.html";
            string jsonPath = "data.json";
            string outputPath = "output.html";

            // Create sample template file
            if (!File.Exists(templatePath))
            {
                string htmlTemplate = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body><p>Formatted date: {{date | date:\"yyyy-MM-dd\"}}</p></body></html>";
                File.WriteAllText(templatePath, htmlTemplate, Encoding.UTF8);
            }

            // Create sample JSON data file
            if (!File.Exists(jsonPath))
            {
                string jsonData = "{ \"date\": \"2023-09-15T00:00:00\" }";
                File.WriteAllText(jsonPath, jsonData, Encoding.UTF8);
            }

            // Load template data from JSON
            TemplateData data = new TemplateData(jsonPath);

            // Load options (default)
            TemplateLoadOptions options = new TemplateLoadOptions();

            // Convert template with data
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, data, options);

            // Save the resulting HTML
            document.Save(outputPath);
            
            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
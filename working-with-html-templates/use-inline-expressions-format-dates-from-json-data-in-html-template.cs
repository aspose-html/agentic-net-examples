// Use inline expressions to format dates from JSON data within the HTML template.

using System;
using System.IO;

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

            // Create a simple HTML template with an inline expression for a date
            string templateContent = "<html><body><p>Formatted Date: {{date | date: \"yyyy-MM-dd\"}}</p></body></html>";
            File.WriteAllText(templatePath, templateContent);

            // Create JSON data containing a date value
            string jsonContent = "{ \"date\": \"2023-08-15T00:00:00\" }";
            File.WriteAllText(jsonPath, jsonContent);

            // Load template data from JSON file
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData(jsonPath);

            // Load template options (default)
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template using the data
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, data, options);

            // Save the resulting HTML
            document.Save(outputPath);

            Console.WriteLine($"Template conversion completed. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
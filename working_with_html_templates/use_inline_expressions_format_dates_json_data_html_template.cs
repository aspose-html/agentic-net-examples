// Use inline expressions to format dates from JSON data within the HTML template.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the HTML template that contains inline expressions for date formatting, e.g., {{date | format:"MM/dd/yyyy"}}
            string templatePath = "template.html";

            // Path to the JSON file with data, including a date field.
            string jsonPath = "data.json";

            // Path where the rendered HTML will be saved.
            string outputPath = "output.html";

            // Load JSON data for merging.
            TemplateData data = new TemplateData(jsonPath);

            // Use default template loading options.
            TemplateLoadOptions options = new TemplateLoadOptions();

            // Merge the template with the JSON data and save the result.
            Converter.ConvertTemplate(templatePath, data, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
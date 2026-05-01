// Create an HTML document, embed a data table using JSON data, and export to HTML.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the HTML template file containing placeholders for the data table
            string templatePath = "template.html";

            // Path to the JSON file that holds the data to be merged into the template
            string jsonPath = "data.json";

            // Path where the resulting HTML document will be saved
            string outputPath = "output.html";

            // Create a TemplateData object that references the JSON data file
            TemplateData templateData = new TemplateData(jsonPath);

            // Initialize default template loading options
            TemplateLoadOptions loadOptions = new TemplateLoadOptions();

            // Merge the template with the JSON data and save the final HTML document
            Converter.ConvertTemplate(templatePath, templateData, loadOptions, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
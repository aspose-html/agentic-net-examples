// Create a TemplateData object from a JSON file and bind it to an HTML template.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            string templatePath = "template.html";
            string jsonPath = "data.json";
            string outputPath = "output.html";

            TemplateData data = new TemplateData(jsonPath);
            TemplateLoadOptions options = new TemplateLoadOptions();

            Converter.ConvertTemplate(templatePath, data, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
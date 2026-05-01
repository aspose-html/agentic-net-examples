// Convert a template that contains a foreach loop into an HTML table with dynamic rows.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

namespace TemplateToHtml
{
    class Program
    {
        static void Main()
        {
            try
            {
                string templatePath = "template.html";
                string jsonPath = "data.json";
                string outputPath = "output.html";

                HTMLDocument document = new HTMLDocument(templatePath);
                string json = File.ReadAllText(jsonPath);
                TemplateData data = new TemplateData(json);
                TemplateLoadOptions options = new TemplateLoadOptions();

                Converter.ConvertTemplate(document, data, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
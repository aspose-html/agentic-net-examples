// Use TemplateData to bind a list of products from JSON and generate a repeating product card layout.

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
            string jsonPath = "products.json";
            string outputPath = "output.html";

            TemplateData templateData = new TemplateData(jsonPath);
            TemplateLoadOptions loadOptions = new TemplateLoadOptions();

            Converter.ConvertTemplate(templatePath, templateData, loadOptions, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
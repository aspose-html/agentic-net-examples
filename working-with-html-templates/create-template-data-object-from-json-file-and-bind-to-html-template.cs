// Create a TemplateData object from a JSON file and bind it to an HTML template.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string jsonPath = "data.json";
            string templatePath = "template.html";
            string outputPath = "output.html";

            if (!File.Exists(jsonPath))
            {
                File.WriteAllText(jsonPath, "{\"title\":\"Hello World\",\"message\":\"This is a test\"}");
            }

            if (!File.Exists(templatePath))
            {
                File.WriteAllText(templatePath, "<html><head><title>{{title}}</title></head><body><p>{{message}}</p></body></html>");
            }

            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonPath);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, templateData, loadOptions, outputPath);

            Console.WriteLine("Template conversion completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
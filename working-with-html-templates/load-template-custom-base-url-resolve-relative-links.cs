// Load a template with custom base URL using TemplateLoadOptions to resolve relative links.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string templatePath = "template.html";
            string outputPath = "output.html";

            if (!File.Exists(templatePath))
            {
                string sampleTemplate = "<html><head><title>{{title}}</title></head><body><img src=\"images/pic.png\" /></body></html>";
                File.WriteAllText(templatePath, sampleTemplate);
            }

            string templateContent = File.ReadAllText(templatePath);
            string baseUrl = "https://example.com/templates/";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(templateContent, baseUrl);

            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData("{\"title\":\"Hello World\"}");

            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);

            resultDocument.Save(outputPath);

            Console.WriteLine("Template converted and saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
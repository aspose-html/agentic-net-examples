// Use inline expressions to format dates from JSON data within the HTML template.

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
                string templateContent = "<html><body><h1>{{title}}</h1><p>{{message}}</p></body></html>";
                File.WriteAllText(templatePath, templateContent);
            }

            string jsonData = "{\"title\":\"Hello World\",\"message\":\"This is a test.\"}";

            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonData);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, templateData, loadOptions);
            document.Save(outputPath);

            Console.WriteLine($"Converted template saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
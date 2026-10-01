// Create a TemplateData object from a JSON file and bind it to an HTML template.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Template HTML with placeholders
            string templateHtml = "<html><body><h1>{{title}}</h1><p>{{message}}</p></body></html>";

            // JSON data for the template
            string jsonData = "{\"title\":\"Hello World\",\"message\":\"This is a sample message.\"}";

            // Create TemplateData from JSON string
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonData);

            // Load options for the template
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template to an HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(templateHtml, templateData, loadOptions);

            // Save the resulting HTML to a file
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Converted HTML saved to {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
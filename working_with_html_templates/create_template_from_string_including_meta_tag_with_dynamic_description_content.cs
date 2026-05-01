// Create a template from a string that includes a meta tag with dynamic description content.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            // HTML template with a meta tag placeholder for description
            string htmlContent = "<!DOCTYPE html><html><head><meta name=\"description\" content=\"{{description}}\"></head><body><h1>Hello World</h1></body></html>";

            // JSON data providing the dynamic description value
            string jsonData = "{\"description\":\"Dynamic description content\"}";

            // Path where the merged HTML will be saved
            string outputPath = "output.html";

            // Create an HTMLDocument from the template string
            HTMLDocument document = new HTMLDocument(htmlContent, "");

            // Create TemplateData from the JSON string
            TemplateData data = new TemplateData(jsonData);

            // Load options for template processing (default settings)
            TemplateLoadOptions options = new TemplateLoadOptions();

            // Merge template with data and save the result
            Converter.ConvertTemplate(document, data, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
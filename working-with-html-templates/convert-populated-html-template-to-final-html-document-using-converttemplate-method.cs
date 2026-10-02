// Convert a populated HTML template to a final HTML document using the ConvertTemplate method.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string sourcePath = "template.html";
            string templateDataPath = "data.json";
            string resultPath = "result.html";

            // Create a minimal HTML template if it does not exist
            if (!File.Exists(sourcePath))
            {
                string htmlTemplate = "<!DOCTYPE html><html><head><title>{{title}}</title></head><body><h1>{{title}}</h1></body></html>";
                File.WriteAllText(sourcePath, htmlTemplate);
            }

            // Create a minimal JSON data file if it does not exist
            if (!File.Exists(templateDataPath))
            {
                string jsonData = "{ \"title\": \"Hello, Aspose.HTML!\" }";
                File.WriteAllText(templateDataPath, jsonData);
            }

            // Load template data
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(templateDataPath);

            // Load the HTML template document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath, new Aspose.Html.Configuration());

            // Set template load options (default)
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template with data
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, loadOptions);

            // Save the final HTML document
            resultDocument.Save(resultPath);

            // Clean up
            resultDocument.Dispose();
            document.Dispose();

            Console.WriteLine("Template conversion completed successfully. Output saved to: " + resultPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
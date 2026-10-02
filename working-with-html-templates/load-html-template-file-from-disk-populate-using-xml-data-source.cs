// Load an HTML template file from disk and populate it using an XML data source.

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
            string inputPath = "template.html";
            string dataPath = "data.xml";
            string outputPath = "result.html";

            // Create a minimal HTML template if it does not exist
            if (!File.Exists(inputPath))
            {
                string templateContent = "<html><body><h1>{{title}}</h1></body></html>";
                File.WriteAllText(inputPath, templateContent);
            }

            // Create a minimal XML data source if it does not exist
            if (!File.Exists(dataPath))
            {
                string xmlContent = "<root><title>Hello World</title></root>";
                File.WriteAllText(dataPath, xmlContent);
            }

            // Load the HTML template
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Load the XML data source
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(dataPath);

            // Set template load options (default)
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template with the data
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, options);

            // Save the populated HTML
            resultDocument.Save(outputPath);

            // Clean up
            resultDocument.Dispose();
            document.Dispose();

            Console.WriteLine("Template populated and saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
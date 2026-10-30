// Load an HTML template file from disk and populate it using an XML data source.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "template.html";
            string xmlPath = "data.xml";
            string outputPath = "result.html";

            // Create sample template file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "<html><body><h1>{{title}}</h1></body></html>");
            }

            // Create sample XML data file if it does not exist
            if (!File.Exists(xmlPath))
            {
                File.WriteAllText(xmlPath,
                    "<data><title>Hello World</title></data>");
            }

            // Load XML data content
            string xmlContent = File.ReadAllText(xmlPath);

            // Load the HTML template
            Aspose.Html.HTMLDocument document =
                new Aspose.Html.HTMLDocument(inputPath);

            // Prepare template data
            Aspose.Html.Converters.TemplateData templateData =
                new Aspose.Html.Converters.TemplateData(xmlContent);

            // Load options for template processing
            Aspose.Html.Loading.TemplateLoadOptions options =
                new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert template with data
            Aspose.Html.HTMLDocument resultDocument =
                Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, options);

            // Save the populated HTML
            resultDocument.Save(outputPath);

            // Clean up
            document.Dispose();
            resultDocument.Dispose();

            Console.WriteLine($"Template processed and saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
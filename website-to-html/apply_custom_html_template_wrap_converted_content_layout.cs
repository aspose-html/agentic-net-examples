// Apply a custom HTML template to wrap converted content for a consistent page layout.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample template file
            string sourcePath = "template.html";
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<html><body><h1>{{title}}</h1></body></html>");
            }

            // Prepare sample template data file (JSON)
            string templateDataPath = "data.json";
            if (!File.Exists(templateDataPath))
            {
                File.WriteAllText(templateDataPath, "{\"title\":\"Hello World\"}");
            }

            // Load template data
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(templateDataPath);

            // Load the HTML document (template)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath, new Aspose.Html.Configuration());

            // Load options for template processing
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template with data
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, options);

            // Save the resulting HTML
            string resultPath = "result.html";
            resultDocument.Save(resultPath);
            Console.WriteLine($"Template conversion completed. Output saved to '{resultPath}'.");

            // -----------------------------------------------------------------
            // Additional example: convert raw HTML string to a file using template data
            // -----------------------------------------------------------------
            string htmlContent = "<html><body><p>{{message}}</p></body></html>";
            string outputPath = "output.html";

            // Create a document from the HTML string
            Aspose.Html.HTMLDocument docFromString = new Aspose.Html.HTMLDocument(htmlContent, "");

            // Create template data directly from a JSON string
            Aspose.Html.Converters.TemplateData dataFromString = new Aspose.Html.Converters.TemplateData("{\"message\":\"This is a test.\"}");

            // Convert the document with the inline template data
            Aspose.Html.HTMLDocument convertedDoc = Aspose.Html.Converters.Converter.ConvertTemplate(docFromString, dataFromString, new Aspose.Html.Loading.TemplateLoadOptions());

            // Save the converted document
            convertedDoc.Save(outputPath);
            Console.WriteLine($"HTML string conversion completed. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
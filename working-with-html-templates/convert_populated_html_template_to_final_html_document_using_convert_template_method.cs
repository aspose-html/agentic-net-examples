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

            // Create minimal sample files if they do not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<html><body><h1>{{title}}</h1></body></html>");
            }

            if (!File.Exists(templateDataPath))
            {
                File.WriteAllText(templateDataPath, "{ \"title\": \"Hello World\" }");
            }

            // Load template data
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(templateDataPath);

            // Load options for template processing
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Load the HTML document (template)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath, new Aspose.Html.Configuration());

            // Perform template conversion
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, loadOptions);

            // Save the resulting HTML
            resultDocument.Save(resultPath);

            // Clean up
            document.Dispose();
            resultDocument.Dispose();

            Console.WriteLine("Template conversion completed successfully. Output saved to: " + resultPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
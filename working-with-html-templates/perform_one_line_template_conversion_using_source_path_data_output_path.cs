// Perform a one‑line template conversion by calling ConvertTemplate with source path, data, and output path.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string sourcePath = "template.html";
            string templateDataPath = "data.json";
            string resultPath = "result.html";

            // Create minimal sample files if they do not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<html><body><h1>Hello {{name}}</h1></body></html>");
            }

            if (!File.Exists(templateDataPath))
            {
                File.WriteAllText(templateDataPath, "{\"name\":\"World\"}");
            }

            // Load template data
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(templateDataPath);

            // Load options
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Load the HTML document (template)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath, new Aspose.Html.Configuration());

            // Perform template conversion
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, options);

            // Save the resulting document
            resultDocument.Save(resultPath);

            Console.WriteLine($"Template conversion completed. Output saved to: {resultPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
// Apply a custom HTML template to wrap converted content for a consistent page layout.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string sourcePath = "source.html";
            string templateDataPath = "template.html";
            string resultPath = "result.html";

            // Create sample source HTML if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<html><body><h1>Hello, World!</h1></body></html>");
            }

            // Create sample template HTML if it does not exist
            if (!File.Exists(templateDataPath))
            {
                // The template should contain a placeholder where the source content will be inserted.
                // Using {{content}} as a placeholder is typical for Aspose HTML templates.
                File.WriteAllText(templateDataPath,
                    "<html><head><title>Template Page</title></head><body><div class=\"wrapper\">{{content}}</div></body></html>");
            }

            // Load the source document
            using Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath, new Aspose.Html.Configuration());

            // Prepare template data
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(templateDataPath);

            // Load template options
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert using the template
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, options);

            // Save the resulting document
            resultDocument.Save(resultPath);

            // Dispose the result document
            resultDocument.Dispose();

            Console.WriteLine($"Template conversion completed successfully. Output saved to '{resultPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
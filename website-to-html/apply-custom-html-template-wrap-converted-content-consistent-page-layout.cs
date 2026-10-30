// Apply a custom HTML template to wrap converted content for a consistent page layout.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;
using Aspose.Html.IO;

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

            // Create a minimal source HTML file if it does not exist
            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "<html><body><h1>Hello, World!</h1></body></html>");
            }

            // Create a minimal template HTML file if it does not exist
            if (!System.IO.File.Exists(templateDataPath))
            {
                // The template should contain a placeholder for the content, e.g., {{content}}
                System.IO.File.WriteAllText(templateDataPath, "<html><head><title>My Template</title></head><body>{{content}}</body></html>");
            }

            // Load the source document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath, new Aspose.Html.Configuration());

            // Load the template data
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(templateDataPath);

            // Set template load options (default)
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Apply the template to the source document
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, options);

            // Save the resulting document
            resultDocument.Save(resultPath);
            
            Console.WriteLine("Template applied and result saved to: " + resultPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
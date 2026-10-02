// Instantiate TemplateLoadOptions to specify custom encoding before loading an HTML template file.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "template.html";
            string outputPath = "output.html";

            // Create a minimal template file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleTemplate = "<html><head><title>{{title}}</title></head><body></body></html>";
                File.WriteAllText(inputPath, sampleTemplate, Encoding.UTF8);
            }

            // Read the template file using a custom encoding
            Encoding customEncoding = Encoding.GetEncoding("windows-1252");
            string htmlContent = File.ReadAllText(inputPath, customEncoding);

            // Load the HTML document from the content string
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Prepare template data (JSON format)
            TemplateData data = new TemplateData("{\"title\":\"Hello World\"}");

            // Instantiate TemplateLoadOptions (no specific properties to set in this API version)
            TemplateLoadOptions options = new TemplateLoadOptions();

            // Convert the template with the provided data and options
            HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);

            // Save the resulting document
            resultDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
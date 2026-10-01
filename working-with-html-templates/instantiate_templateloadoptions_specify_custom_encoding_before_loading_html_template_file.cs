// Instantiate TemplateLoadOptions to specify custom encoding before loading an HTML template file.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for template conversion
            string inputPath = "template.html";
            string outputPath = "result.html";

            // Create a minimal template file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Hello {{name}}!</h1></body></html>", Encoding.UTF8);
            }

            // Load the template document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Prepare template data (JSON format)
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData("{\"name\":\"World\"}");

            // Template load options (default)
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template; ConvertTemplate returns a new HTMLDocument
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);

            // Save the converted document
            resultDocument.Save(outputPath);

            // -----------------------------------------------------------------
            // Additional example: load HTML content with a specific encoding and save as PDF
            // -----------------------------------------------------------------
            string sourcePath = "source.html";
            string pdfOutputPath = "output.pdf";

            // Create a minimal source file with a specific encoding if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<html><body><p>Sample content</p></body></html>", Encoding.GetEncoding("windows-1252"));
            }

            // Read the HTML content using the specified encoding
            string htmlContent = File.ReadAllText(sourcePath, Encoding.GetEncoding("windows-1252"));

            // Load the HTML content into a document (second argument is base URL, empty in this case)
            Aspose.Html.HTMLDocument htmlDocument = new Aspose.Html.HTMLDocument(htmlContent, "");

            // Save the document as PDF
            htmlDocument.Save(pdfOutputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
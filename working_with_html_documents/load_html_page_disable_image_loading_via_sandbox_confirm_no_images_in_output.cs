// Load an HTML page, disable image loading via sandbox, and confirm no images appear in output.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a simple HTML file containing an image
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";
            string htmlContent = "<html><body><h1>Test</h1><img src='https://example.com/image.jpg' /></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Create configuration and disable image loading via sandbox
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Images;

            // Load the HTML document with the sandbox configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration);

            // Convert the document to PDF; images will be omitted
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
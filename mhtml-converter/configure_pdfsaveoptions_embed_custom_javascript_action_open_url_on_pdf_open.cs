// Configure PdfSaveOptions to embed a custom JavaScript action that opens a URL when the PDF is opened.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputHtmlPath = "sample.html";
            string outputPdfPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputHtmlPath))
            {
                File.WriteAllText(inputHtmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Configure Aspose.HTML to allow script execution
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Load the HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(inputHtmlPath, config);

            // Set up PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Note: Embedding custom JavaScript actions on PDF open is not available via the current PdfSaveOptions API.

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(doc, options, outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
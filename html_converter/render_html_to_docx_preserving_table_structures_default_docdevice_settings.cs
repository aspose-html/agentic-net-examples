// Render HTML to DOCX while preserving table structures by using default DocDevice settings.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Doc;

class Program
{
    static void Main()
    {
        try
        {
            // Source HTML URL
            string htmlUrl = "https://example.com/sample.html";
            // Destination DOCX file path
            string outputPath = "output.docx";

            // Load the HTML document from the URL
            HTMLDocument document = new HTMLDocument(htmlUrl);

            // Create default rendering options for DOCX output
            DocRenderingOptions options = new DocRenderingOptions();

            // Initialize the DOCX device with the options and output path
            DocDevice device = new DocDevice(options, outputPath);

            // Render the HTML document to the DOCX file
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
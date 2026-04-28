// Convert HTML to DOCX while preserving table structures by using default DocRenderingOptions.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Doc;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string inputPath = "input.html";
            // Path where the resulting DOCX will be saved
            string outputPath = "output.docx";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create default rendering options for DOCX
            DocRenderingOptions docOptions = new DocRenderingOptions();

            // Create a device that writes the rendered content to a DOCX file
            DocDevice device = new DocDevice(docOptions, outputPath);

            // Render the HTML document to DOCX preserving tables and other structures
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
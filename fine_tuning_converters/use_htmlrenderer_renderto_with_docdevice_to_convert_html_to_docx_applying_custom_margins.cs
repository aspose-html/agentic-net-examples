// Use HtmlRenderer.RenderTo with a DocDevice to convert HTML to DOCX while applying custom margins.

using System;
using Aspose.Html;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Doc;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the source HTML file and the target DOCX file
            string htmlPath = "input.html";
            string outputPath = "output.docx";

            // Load the HTML document from the file system
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create rendering options for DOCX output
            DocRenderingOptions options = new DocRenderingOptions();

            // Define custom page size (e.g., 600x400 pixels) and uniform margins of 10 pixels
            Size pageSize = new Size(600, 400);
            Margin pageMargin = new Margin(10, 10, 10, 10);
            Page page = new Page(pageSize, pageMargin);

            // Apply the custom page setup to the rendering options
            options.PageSetup.AnyPage = page;

            // Create a DocDevice that writes the rendered content to the specified DOCX file
            DocDevice device = new DocDevice(options, outputPath);

            // Render the HTML document to the DOCX file using the configured device
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
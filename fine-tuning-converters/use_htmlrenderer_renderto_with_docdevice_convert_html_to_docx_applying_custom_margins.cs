// Use HtmlRenderer.RenderTo with a DocDevice to convert HTML to DOCX while applying custom margins.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1><p>This is a sample document.</p></body></html>";

            // Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Create rendering options
            Aspose.Html.Rendering.Doc.DocRenderingOptions options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();

            // Define page size (width, height) in points
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(800, 1100);

            // Define custom margins (left, top, right, bottom) in points (1 inch = 72 points)
            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(72, 72, 72, 72);

            // Apply page setup with custom size and margins
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(pageSize, pageMargin);

            // Embed all fonts
            options.FontEmbeddingRule = Aspose.Html.Rendering.Doc.FontEmbeddingRule.Full;

            // Output DOCX file path
            string outputPath = "output.docx";

            // Create DOC device with the rendering options
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(options, outputPath);

            // Render HTML to DOCX
            document.RenderTo(device);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
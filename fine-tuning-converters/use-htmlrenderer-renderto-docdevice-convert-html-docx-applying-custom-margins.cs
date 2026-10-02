// Use HtmlRenderer.RenderTo with a DocDevice to convert HTML to DOCX while applying custom margins.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string html = "<html><body><h1>Hello, World!</h1><p>This is a sample document.</p></body></html>";

            // Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

            // Create rendering options for DOCX
            Aspose.Html.Rendering.Doc.DocRenderingOptions docOptions = new Aspose.Html.Rendering.Doc.DocRenderingOptions();

            // Define page size (8 inches width x 11 inches height)
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8),
                Aspose.Html.Drawing.Length.FromInches(11));

            // Define custom margins (1 inch on each side)
            Aspose.Html.Drawing.Margin margins = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1));

            // Apply page size and margins
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margins);
            docOptions.PageSetup.AnyPage = page;

            // Embed fonts fully (optional)
            docOptions.FontEmbeddingRule = Aspose.Html.Rendering.Doc.FontEmbeddingRule.Full;

            // Output DOCX file path
            string outputPath = "output.docx";

            // Create DOC device with the options and output path
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(docOptions, outputPath);

            // Render HTML to DOCX
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Apply a custom background color to all outputs by passing a shared RenderingOptions instance to each device.

using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML contents
            string html1 = "<html><body><h1>Document 1</h1><p>This is the first document.</p></body></html>";
            string html2 = "<html><body><h1>Document 2</h1><p>This is the second document.</p></body></html>";
            string html3 = "<html><body><h1>Document 3</h1><p>This is the third document.</p></body></html>";
            string baseUri = "about:blank";
            string outputPath = "output.pdf";

            // Create HTML documents from inline content
            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(html1, baseUri);
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(html2, baseUri);
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(html3, baseUri);

            // Shared rendering options with custom background color
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.BackgroundColor = Color.AliceBlue; // Custom background color

            // Page setup (optional)
            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(800, 600);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size);
            options.PageSetup.AnyPage = page;

            // Create renderer and device using the shared options
            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);

            // Render all documents to the same PDF using the shared options
            renderer.Render(device, document1, document2, document3);

            Console.WriteLine("PDF generated successfully at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
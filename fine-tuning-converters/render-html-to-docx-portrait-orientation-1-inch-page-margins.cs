// Render HTML to DOCX with DocRenderingOptions specifying portrait orientation and 1‑inch page margins.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello World</h1><p>This is a sample document.</p></body></html>";

            // Create HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure rendering options: portrait orientation, 1-inch margins
            Aspose.Html.Rendering.Doc.DocRenderingOptions renderingOptions = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5),
                Aspose.Html.Drawing.Length.FromInches(11));
            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1));
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);
            renderingOptions.PageSetup.AnyPage = page;
            renderingOptions.FontEmbeddingRule = Aspose.Html.Rendering.Doc.FontEmbeddingRule.Full;

            // Output DOCX file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.docx");

            // Create rendering device
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(renderingOptions, outputPath);

            // Render HTML to DOCX
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
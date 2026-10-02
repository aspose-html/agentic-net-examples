// Render HTML to DOCX with DocRenderingOptions specifying portrait orientation and 1‑inch page margins.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Doc;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Doc;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, World!</h1><p>This is a sample document.</p></body></html>";

            // Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure rendering options: portrait orientation, 1-inch margins
            Aspose.Html.Rendering.Doc.DocRenderingOptions options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();

            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5),
                Aspose.Html.Drawing.Length.FromInches(11));

            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1),
                Aspose.Html.Drawing.Length.FromInches(1));

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);
            options.PageSetup.AnyPage = page;

            // Output DOCX file path
            string outputPath = "output.docx";

            // Create rendering device and render
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(options, outputPath);
            document.RenderTo(device);

            Console.WriteLine("HTML has been successfully rendered to DOCX: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
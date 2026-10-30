// Render HTML to DOCX with custom page size of 8.5 by 14 inches using DocRenderingOptions.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Doc;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1><p>This is a test document.</p></body></html>";

            // Create HTMLDocument from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure rendering options with custom page size (8.5 x 14 inches)
            Aspose.Html.Rendering.Doc.DocRenderingOptions options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.5),
                    Aspose.Html.Drawing.Length.FromInches(14)
                )
            );
            options.FontEmbeddingRule = Aspose.Html.Rendering.Doc.FontEmbeddingRule.Full;

            // Output DOCX path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.docx");

            // Create device and render
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(options, outputPath);
            document.RenderTo(device);

            Console.WriteLine("HTML has been successfully rendered to DOCX at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
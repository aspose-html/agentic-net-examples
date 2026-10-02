// Render HTML to DOCX with custom page orientation set to Landscape via DocRenderingOptions.

using System;
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
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, World!</h1></body></html>";

            // Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure rendering options with landscape page orientation
            Aspose.Html.Rendering.Doc.DocRenderingOptions options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(11),
                    Aspose.Html.Drawing.Length.FromInches(8)
                )
            );
            options.FontEmbeddingRule = Aspose.Html.Rendering.Doc.FontEmbeddingRule.Full;

            // Create DOCX device
            string outputPath = "output.docx";
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(options, outputPath);

            // Render HTML to DOCX
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
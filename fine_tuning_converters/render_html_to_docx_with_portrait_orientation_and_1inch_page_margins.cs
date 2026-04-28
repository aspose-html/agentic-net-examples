// Render HTML to DOCX with DocRenderingOptions specifying portrait orientation and 1‑inch page margins.

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
            string htmlPath = "input.html";
            string outputPath = "output.docx";

            HTMLDocument document = new HTMLDocument(htmlPath);

            DocRenderingOptions options = new DocRenderingOptions();
            options.PageSetup.AnyPage = new Page(
                new Size(
                    Length.FromInches(8.5),
                    Length.FromInches(11)
                )
            );
            options.PageSetup.AnyPage.Margin = new Margin(
                Length.FromInches(1),
                Length.FromInches(1),
                Length.FromInches(1),
                Length.FromInches(1)
            );
            options.FontEmbeddingRule = FontEmbeddingRule.Full;

            DocDevice device = new DocDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
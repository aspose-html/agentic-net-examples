// Render HTML to DOCX with custom page orientation set to Landscape via DocRenderingOptions.

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
            string htmlPath = "input.html";
            string outputPath = "output.docx";

            HTMLDocument document = new HTMLDocument(htmlPath);
            DocRenderingOptions options = new DocRenderingOptions();
            options.PageSetup.AnyPage = new Page(
                new Size(
                    Length.FromInches(10),
                    Length.FromInches(8)));
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
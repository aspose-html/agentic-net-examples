// Render HTML to DOCX with custom page size of 8.5 by 14 inches using DocRenderingOptions.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Doc;
using Aspose.Html.Drawing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.docx";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Rendering.Doc.DocRenderingOptions options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.5),
                    Aspose.Html.Drawing.Length.FromInches(14)));
            options.FontEmbeddingRule = Aspose.Html.Rendering.Doc.FontEmbeddingRule.Full;
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
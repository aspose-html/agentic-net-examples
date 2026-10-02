// Render HTML to DOCX with custom page size of 8.5 by 14 inches using DocRenderingOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, World!</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var renderingOptions = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
            renderingOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.5),
                    Aspose.Html.Drawing.Length.FromInches(14)));
            renderingOptions.FontEmbeddingRule = Aspose.Html.Rendering.Doc.FontEmbeddingRule.Full;

            string outputPath = "output.docx";
            var device = new Aspose.Html.Rendering.Doc.DocDevice(renderingOptions, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Render HTML to DOCX with custom page orientation set to Landscape via DocRenderingOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, World!</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);

            Aspose.Html.Rendering.Doc.DocRenderingOptions renderOptions = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
            renderOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(11),
                    Aspose.Html.Drawing.Length.FromInches(8.5)));
            renderOptions.FontEmbeddingRule = Aspose.Html.Rendering.Doc.FontEmbeddingRule.Full;

            string outputPath = "output.docx";
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(renderOptions, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
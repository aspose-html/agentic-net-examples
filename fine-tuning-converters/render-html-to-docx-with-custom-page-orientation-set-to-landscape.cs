// Render HTML to DOCX with custom page orientation set to Landscape via DocRenderingOptions.

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
            // Landscape orientation: width 11 inches, height 8.5 inches
            renderingOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(11),
                    Aspose.Html.Drawing.Length.FromInches(8.5)));

            renderingOptions.FontEmbeddingRule = Aspose.Html.Rendering.Doc.FontEmbeddingRule.Full;

            var device = new Aspose.Html.Rendering.Doc.DocDevice(renderingOptions, "output.docx");
            document.RenderTo(device);

            Console.WriteLine("HTML successfully rendered to DOCX with landscape orientation.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
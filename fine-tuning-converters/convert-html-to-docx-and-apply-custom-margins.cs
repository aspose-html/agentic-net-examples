// Use HtmlRenderer.RenderTo with a DocDevice to convert HTML to DOCX while applying custom margins.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string html = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1><p>This is a sample document.</p></body></html>";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

                Aspose.Html.Rendering.Doc.DocRenderingOptions options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();

                Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8),
                    Aspose.Html.Drawing.Length.FromInches(11));

                Aspose.Html.Drawing.Margin margins = new Aspose.Html.Drawing.Margin(72, 72, 72, 72);

                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margins);
                options.PageSetup.AnyPage = page;
                options.FontEmbeddingRule = Aspose.Html.Rendering.Doc.FontEmbeddingRule.Full;

                string outputPath = "output.docx";
                Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(options, outputPath);

                document.RenderTo(device);

                System.Console.WriteLine("Conversion completed successfully. Output saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
// Render HTML to DOCX while preserving table structures by using default DocDevice settings.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><table border='1'><tr><td>Cell 1</td><td>Cell 2</td></tr></table></body></html>";
            string outputPath = "output.docx";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);
            Aspose.Html.Rendering.Doc.DocRenderingOptions options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
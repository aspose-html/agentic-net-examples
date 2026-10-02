// Render HTML to DOCX while preserving table structures by using default DocDevice settings.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body><h1>Sample Table</h1><table border=\"1\"><tr><th>Header 1</th><th>Header 2</th></tr><tr><td>Cell 1</td><td>Cell 2</td></tr></table></body></html>";
            string outputPath = "output.docx";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Rendering.Doc.DocRenderingOptions options = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
            Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(options, outputPath);
            document.RenderTo(device);

            Console.WriteLine("HTML successfully rendered to DOCX: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
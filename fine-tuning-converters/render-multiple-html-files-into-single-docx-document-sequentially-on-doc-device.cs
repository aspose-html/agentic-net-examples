// Render multiple HTML files into a single DOCX document by sequentially invoking HtmlRenderer.RenderTo on a DocDevice.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            string html1Path = Path.Combine(outputDir, "sample1.html");
            string html2Path = Path.Combine(outputDir, "sample2.html");

            File.WriteAllText(html1Path, "<html><body><h1>First Document</h1><p>Hello World!</p></body></html>");
            File.WriteAllText(html2Path, "<html><body><h1>Second Document</h1><p>Another page.</p></body></html>");

            string docxPath = Path.Combine(outputDir, "Combined.docx");

            Aspose.Html.Rendering.Doc.DocRenderingOptions docOptions = new Aspose.Html.Rendering.Doc.DocRenderingOptions();
            using (Aspose.Html.Rendering.Doc.DocDevice device = new Aspose.Html.Rendering.Doc.DocDevice(docOptions, docxPath))
            {
                Aspose.Html.HTMLDocument doc1 = new Aspose.Html.HTMLDocument(html1Path);
                doc1.RenderTo(device);

                Aspose.Html.HTMLDocument doc2 = new Aspose.Html.HTMLDocument(html2Path);
                doc2.RenderTo(device);
            }

            Console.WriteLine("DOCX created at: " + docxPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
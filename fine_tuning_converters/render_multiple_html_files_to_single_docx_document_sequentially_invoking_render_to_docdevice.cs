// Render multiple HTML files into a single DOCX document by sequentially invoking HtmlRenderer.RenderTo on a DocDevice.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Doc;

class Program
{
    static void Main()
    {
        try
        {
            string[] htmlFiles = new string[] { "file1.html", "file2.html", "file3.html" };
            string outputDocx = "merged.docx";

            DocRenderingOptions docOptions = new DocRenderingOptions();
            DocDevice device = new DocDevice(docOptions, outputDocx);

            foreach (string htmlPath in htmlFiles)
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    document.RenderTo(device);
                }
            }

            device.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
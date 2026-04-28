// Render multiple HTML files into a single XPS document by sequentially calling HtmlRenderer.RenderTo on one XpsDevice.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Xps;

class Program
{
    static void Main()
    {
        try
        {
            string[] htmlFiles = { "file1.html", "file2.html", "file3.html" };
            string outputXps = "merged.xps";

            using (XpsDevice device = new XpsDevice(outputXps))
            {
                foreach (var htmlPath in htmlFiles)
                {
                    using (HTMLDocument doc = new HTMLDocument(htmlPath))
                    {
                        doc.RenderTo(device);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Create a document, add a link to external CSS, and ensure styles are applied after rendering.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head></head><body><p>Hello World</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var link = document.CreateElement("link");
            link.SetAttribute("rel", "stylesheet");
            link.SetAttribute("href", "https://example.com/style.css");

            var heads = document.GetElementsByTagName("head");
            if (heads.Length > 0)
            {
                var head = heads[0];
                head.AppendChild(link);
            }

            string outputPath = "output.pdf";
            var device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
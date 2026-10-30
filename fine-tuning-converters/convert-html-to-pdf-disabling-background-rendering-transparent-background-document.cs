// Convert HTML to PDF while disabling background rendering to produce a transparent‑background document.

using System;
using System.IO;
using System.Drawing;

namespace HTMLToPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "sample.html";
                string pdfPath = "output.pdf";

                if (!File.Exists(htmlPath))
                {
                    File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, PDF!</h1></body></html>");
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                options.BackgroundColor = System.Drawing.Color.Transparent;

                Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);

                document.RenderTo(device);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
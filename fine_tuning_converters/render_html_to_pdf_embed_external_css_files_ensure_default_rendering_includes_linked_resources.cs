// Render HTML to PDF and embed all external CSS files by ensuring default rendering includes linked resources.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;

namespace HtmlToPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = @"<html><head><link rel='stylesheet' href='style.css'></head><body><h1>Hello World</h1></body></html>";
                string baseUri = AppDomain.CurrentDomain.BaseDirectory;
                string htmlPath = System.IO.Path.Combine(baseUri, "output.html");
                string pdfPath = System.IO.Path.Combine(baseUri, "output.pdf");

                HTMLDocument document = new HTMLDocument(htmlContent, baseUri);
                document.Save(htmlPath);

                using (PdfDevice device = new PdfDevice(pdfPath))
                {
                    document.RenderTo(device);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
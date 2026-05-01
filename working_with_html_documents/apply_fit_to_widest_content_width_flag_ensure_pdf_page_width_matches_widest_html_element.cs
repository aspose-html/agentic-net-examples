// Apply FitToWidestContentWidth flag to ensure PDF page width matches the widest element in HTML.

using System;
using Aspose.Html;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;

namespace FitToWidestContentWidthExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "input.html";
                string pdfPath = "output.pdf";

                HTMLDocument document = new HTMLDocument(htmlPath);
                PdfRenderingOptions options = new PdfRenderingOptions();
                options.PageSetup.PageLayoutOptions = PageLayoutOptions.FitToWidestContentWidth;
                PdfDevice device = new PdfDevice(options, pdfPath);
                document.RenderTo(device);
                device.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
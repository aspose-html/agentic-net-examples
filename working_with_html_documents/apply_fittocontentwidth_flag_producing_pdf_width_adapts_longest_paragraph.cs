// Apply FitToContentWidth flag only, producing a PDF where width adapts to longest paragraph.

using System;
using Aspose.Html;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;

namespace HtmlToPdfFitWidth
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
                options.PageSetup.PageLayoutOptions = Aspose.Html.Rendering.PageLayoutOptions.FitToContentWidth;
                PdfDevice device = new PdfDevice(options, pdfPath);
                document.RenderTo(device);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
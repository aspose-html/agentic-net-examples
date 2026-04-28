// Configure PdfRenderingOptions to set right margin to 0.75 inches, ensuring consistent right‑hand spacing.

using System;
using Aspose.Html;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Pdf;

namespace HtmlToPdfMarginExample
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

                // Define margins: left, top, right, bottom (in inches)
                Margin margin = new Margin(
                    Length.FromInches(0.5),   // left
                    Length.FromInches(0.5),   // top
                    Length.FromInches(0.75),  // right
                    Length.FromInches(0.5)    // bottom
                );

                // Define page size (A4 in points)
                Size size = new Size(595, 842);
                Page page = new Page(size, margin);

                options.PageSetup.AnyPage = page;

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
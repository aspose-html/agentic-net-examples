// Render HTML to PDF with custom right margin of 12 points to accommodate binding requirements.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

namespace HtmlToPdfWithMargin
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlPath = "input.html";
                string pdfPath = "output.pdf";

                HTMLDocument document = new HTMLDocument(htmlPath);

                PdfRenderingOptions options = new PdfRenderingOptions();

                // Define margins: left 0.5", right 12 points (0.1667"), bottom 0.5", top 0.5"
                Margin margin = new Margin(
                    Length.FromInches(0.5),          // left
                    Length.FromInches(0.1666667),   // right (12 points)
                    Length.FromInches(0.5),          // bottom
                    Length.FromInches(0.5)           // top
                );

                // Page size (A4 in points)
                Size size = new Size(595, 842);

                Page page = new Page(size, margin);
                options.PageSetup.AnyPage = page;

                PdfDevice device = new PdfDevice(options, pdfPath);
                document.RenderTo(device);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
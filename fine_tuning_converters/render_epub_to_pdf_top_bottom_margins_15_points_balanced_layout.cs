// Render an EPUB to PDF and set both top and bottom margins to 15 points for balanced layout.

using System;
using System.IO;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "input.epub";
            string pdfPath = "output.pdf";

            using (FileStream stream = File.OpenRead(epubPath))
            {
                PdfRenderingOptions options = new PdfRenderingOptions();
                options.PageSetup.AnyPage = new Page(new Size(Length.FromPoints(595), Length.FromPoints(842)));
                options.PageSetup.AnyPage.Margin = new Margin(15, 0, 15, 0);

                PdfDevice device = new PdfDevice(options, pdfPath);
                EpubRenderer renderer = new EpubRenderer();
                renderer.Render(device, stream);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
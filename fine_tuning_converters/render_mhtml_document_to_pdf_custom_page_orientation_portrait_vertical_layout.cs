// Render an MHTML document to PDF with a custom page orientation set to Portrait for vertical layout.

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
            string inputPath = "input.mhtml";
            string outputPath = "output.pdf";

            using (FileStream stream = File.OpenRead(inputPath))
            using (MhtmlRenderer renderer = new MhtmlRenderer())
            {
                PdfRenderingOptions options = new PdfRenderingOptions();
                options.PageSetup.AnyPage = new Page(new Size(595, 842));
                options.BackgroundColor = System.Drawing.Color.White;

                using (PdfDevice device = new PdfDevice(options, outputPath))
                {
                    renderer.Render(device, stream);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
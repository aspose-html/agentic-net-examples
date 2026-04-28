// Convert an MHTML document to PDF while applying custom page dimensions via PdfDevice.AnyPage property.

using System;
using System.IO;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

namespace MhtmlToPdfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.mhtml";
                string outputPath = "output.pdf";

                using (FileStream stream = File.OpenRead(inputPath))
                {
                    MhtmlRenderer renderer = new MhtmlRenderer();
                    PdfRenderingOptions options = new PdfRenderingOptions();
                    options.PageSetup.AnyPage = new Page(new Size(595, 842));
                    PdfDevice device = new PdfDevice(options, outputPath);
                    renderer.Render(device, stream);
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
// Convert an MHTML document to PDF while applying custom page dimensions via PdfDevice.AnyPage property.

using System;
using System.IO;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "result.pdf";

            if (!File.Exists(inputPath))
            {
                string mhtmlContent = "From: <Saved by WebKit>\nSubject: Test\nDate: Thu, 1 Jan 1970 00:00:00 GMT\nMIME-Version: 1.0\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\n\n------=_NextPart_000_0000\nContent-Type: text/html; charset=\"utf-8\"\nContent-Transfer-Encoding: quoted-printable\n\n<html><body><h1>Hello MHTML</h1></body></html>\n------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                PdfRenderingOptions options = new PdfRenderingOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));
                options.BackgroundColor = System.Drawing.Color.AliceBlue;

                PdfDevice device = new PdfDevice(options, outputPath);

                MhtmlRenderer renderer = new MhtmlRenderer();
                renderer.Render(device, stream);
            }

            Console.WriteLine("MHTML successfully converted to PDF with custom page dimensions.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}
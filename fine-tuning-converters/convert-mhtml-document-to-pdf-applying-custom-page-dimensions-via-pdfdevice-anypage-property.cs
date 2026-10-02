// Convert an MHTML document to PDF while applying custom page dimensions via PdfDevice.AnyPage property.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.pdf";

            if (!System.IO.File.Exists(inputPath))
            {
                string mhtmlContent = "From: <Saved by WebKit>\r\nSubject: Sample MHTML\r\nMIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\nContent-Transfer-Encoding: quoted-printable\r\n\r\n<html><body><h1>Hello, MHTML!</h1></body></html>\r\n------=_NextPart_000_0000--";
                System.IO.File.WriteAllText(inputPath, mhtmlContent);
            }

            using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));
                var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);
                var renderer = new Aspose.Html.Rendering.MhtmlRenderer();
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
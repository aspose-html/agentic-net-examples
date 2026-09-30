// Convert an MHTML document to PDF while applying custom page dimensions via PdfDevice.AnyPage property.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.mhtml";
            string outputPath = "result.pdf";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string mhtmlContent = @"From: <Saved by WebKit>
Subject: 
Date: 
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Hello MHTML</h1></body></html>
------=_NextPart_000_0000--";

                File.WriteAllText(inputPath, mhtmlContent);
            }

            // Open the MHTML file as a read stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Initialize the MHTML renderer
                Aspose.Html.Rendering.MhtmlRenderer renderer = new Aspose.Html.Rendering.MhtmlRenderer();

                // Configure PDF rendering options with custom page size
                Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(595, 842) // Width x Height in points (e.g., A4)
                );
                options.BackgroundColor = Color.AliceBlue;

                // Create PDF device with the specified options and output path
                Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);

                // Perform the conversion
                renderer.Render(device, stream);
            }

            Console.WriteLine("MHTML has been successfully converted to PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}
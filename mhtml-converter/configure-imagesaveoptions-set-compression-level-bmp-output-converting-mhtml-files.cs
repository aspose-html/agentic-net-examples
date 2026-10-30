// Configure ImageSaveOptions to set compression level for BMP output when converting MHTML files.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input MHTML file
            string inputPath = "sample.mhtml";
            if (!File.Exists(inputPath))
            {
                string mhtmlContent =
                    "Content-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n" +
                    "\r\n" +
                    "------=_NextPart_000_0000\r\n" +
                    "Content-Type: text/html; charset=\"utf-8\"\r\n" +
                    "\r\n" +
                    "<html><body><h1>Hello BMP</h1></body></html>\r\n" +
                    "------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            // Output BMP file path
            string outputPath = "output.bmp";

            // Open the MHTML file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for BMP
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

                // Optional rendering properties
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;
                // options.UseAntialiasing = true; // uncomment if needed

                // Convert MHTML to BMP image
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
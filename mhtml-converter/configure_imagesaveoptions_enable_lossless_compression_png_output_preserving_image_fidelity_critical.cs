// Configure ImageSaveOptions to enable lossless compression for PNG output when preserving image fidelity is critical.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.mhtml";
            string outputPath = "output.png";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string mhtmlContent = "From: <Saved by WebKit>\r\n" +
                                      "Content-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n" +
                                      "------=_NextPart_000_0000\r\n" +
                                      "Content-Type: text/html; charset=\"utf-8\"\r\n\r\n" +
                                      "<html><body><h1>Hello, PNG!</h1></body></html>\r\n" +
                                      "------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            // Open the MHTML file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Configure ImageSaveOptions for PNG with lossless compression (default for PNG)
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Convert MHTML to PNG
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
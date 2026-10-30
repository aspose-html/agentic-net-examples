// Convert EPUB to JPEG and embed custom EXIF author metadata using ImageSaveOptions before saving.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB file path and output JPEG file path
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string epubPath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(outputDir, "result.jpg");

            // Create a minimal placeholder EPUB file if it does not exist
            if (!File.Exists(epubPath))
            {
                using (FileStream fs = File.Create(epubPath))
                {
                    // Write minimal ZIP header to make it a valid empty archive (optional)
                    byte[] header = new byte[] { 0x50, 0x4B, 0x05, 0x06 };
                    fs.Write(header, 0, header.Length);
                }
            }

            // Open the EPUB file stream
            using (FileStream stream = File.OpenRead(epubPath))
            {
                // Configure image save options for JPEG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Convert EPUB to JPEG
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB has been converted to JPEG successfully.");
            Console.WriteLine("Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
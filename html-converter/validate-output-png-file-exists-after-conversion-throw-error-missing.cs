// Validate that the output PNG file exists after conversion and throw an error if missing.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.epub");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");

            // Ensure a sample EPUB file exists (empty placeholder)
            if (!File.Exists(inputPath))
            {
                using (FileStream fs = File.Create(inputPath))
                {
                    // Write minimal EPUB header (ZIP file signature) to avoid immediate format errors
                    byte[] header = new byte[] { 0x50, 0x4B, 0x03, 0x04 };
                    fs.Write(header, 0, header.Length);
                }
            }

            // Open the EPUB file stream
            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                // Set up image save options (defaults)
                ImageSaveOptions options = new ImageSaveOptions();

                // Convert EPUB to PNG
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            // Validate that the output file was created
            if (!File.Exists(outputPath))
            {
                throw new FileNotFoundException("The output PNG file was not created.", outputPath);
            }

            Console.WriteLine("Conversion successful. Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
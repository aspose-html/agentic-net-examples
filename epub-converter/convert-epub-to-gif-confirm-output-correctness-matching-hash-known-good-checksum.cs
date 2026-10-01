// Convert EPUB to GIF and confirm output correctness by matching its hash with a known good checksum.

using System;
using System.IO;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB file and output GIF file paths
            string inputPath = "sample.epub";
            string outputPath = "output.gif";

            // Known good SHA256 checksum of the expected GIF file
            const string knownChecksum = "d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2d2";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Open the EPUB file as a stream
            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                // Configure image save options for GIF format
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            // Compute SHA256 hash of the generated GIF
            if (!File.Exists(outputPath))
            {
                Console.WriteLine($"Conversion failed, output file not created: {outputPath}");
                return;
            }

            string computedChecksum;
            using (FileStream gifStream = File.OpenRead(outputPath))
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(gifStream);
                computedChecksum = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }

            // Compare the computed checksum with the known good checksum
            if (computedChecksum == knownChecksum.ToLowerInvariant())
            {
                Console.WriteLine("Conversion successful. Checksum matches the known good value.");
            }
            else
            {
                Console.WriteLine($"Checksum mismatch. Expected: {knownChecksum}");
                Console.WriteLine($"Actual:   {computedChecksum}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
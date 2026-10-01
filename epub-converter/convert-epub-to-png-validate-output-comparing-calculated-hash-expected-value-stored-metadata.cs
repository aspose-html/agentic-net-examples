// Convert EPUB to PNG and validate the output by comparing calculated hash with expected value stored in metadata.

using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input EPUB file and output PNG path
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string epubPath = Path.Combine(dataDir, "sample.epub");
            string pngPath = Path.Combine(outputDir, "result.png");

            // Ensure the EPUB file exists (placeholder - in real scenario provide a valid EPUB)
            if (!File.Exists(epubPath))
            {
                // Create an empty placeholder file to avoid FileNotFoundException in the example
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            // Configure image save options
            ImageSaveOptions options = new ImageSaveOptions();
            options.Format = ImageFormat.Png;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            // Convert EPUB to PNG
            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, pngPath);
            }

            // Compute SHA256 hash of the generated PNG
            string computedHash;
            using (FileStream pngStream = File.OpenRead(pngPath))
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(pngStream);
                computedHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }

            // Expected hash (placeholder value; replace with actual expected hash from metadata)
            string expectedHash = "d41d8cd98f00b204e9800998ecf8427e";

            // Validate hash
            if (computedHash == expectedHash)
            {
                Console.WriteLine("Validation succeeded: hash matches expected value.");
            }
            else
            {
                Console.WriteLine($"Validation failed: expected {expectedHash}, but got {computedHash}.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
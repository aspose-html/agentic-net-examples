// Convert EPUB to GIF and confirm output correctness by matching its hash with a known good checksum.

using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source EPUB file
            string inputPath = "input.epub";
            // Path where the resulting GIF will be saved
            string outputPath = "output.gif";

            // Open the EPUB file as a readable stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Set up image save options to produce a GIF image
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // Convert the EPUB stream to a GIF file
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            // Known good SHA256 checksum for verification
            string knownChecksum = "YOUR_KNOWN_CHECKSUM_HERE";

            // Compute the SHA256 hash of the generated GIF file
            using (FileStream fs = File.OpenRead(outputPath))
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hashBytes = sha.ComputeHash(fs);
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

                // Compare the computed hash with the known checksum
                if (hashString == knownChecksum.ToLowerInvariant())
                {
                    Console.WriteLine("Hash matches. Conversion successful.");
                }
                else
                {
                    Console.WriteLine($"Hash mismatch. Expected {knownChecksum}, got {hashString}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
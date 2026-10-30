// Convert EPUB to GIF and confirm output correctness by matching its hash with a known good checksum.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input EPUB file path (replace with a valid file if needed)
            string inputPath = "sample.epub";
            // Output GIF file path
            string outputPath = "output.gif";

            // Open the EPUB file as a stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                // Configure image save options for GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                // Convert EPUB to GIF
                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, outputPath);
            }

            // Verify that the output file was created
            if (File.Exists(outputPath))
            {
                // Compute SHA256 hash of the generated GIF
                byte[] fileBytes = File.ReadAllBytes(outputPath);
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(fileBytes);
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        sb.Append(b.ToString("x2"));
                    }
                    string computedHash = sb.ToString();

                    // Known good checksum (replace with actual value)
                    string knownHash = "PUT_KNOWN_CHECKSUM_HERE".ToLowerInvariant();

                    if (computedHash == knownHash)
                    {
                        Console.WriteLine("Output GIF hash matches the known checksum.");
                    }
                    else
                    {
                        Console.WriteLine($"Hash mismatch. Computed: {computedHash}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Output file was not created.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Convert EPUB to GIF and confirm output correctness by matching its hash with a known good checksum.

using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.gif";

            // Create a minimal EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                using (FileStream fs = File.Create(inputPath))
                using (ZipArchive zip = new ZipArchive(fs, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry entry = zip.CreateEntry("mimetype");
                    using (Stream entryStream = entry.Open())
                    using (StreamWriter writer = new StreamWriter(entryStream))
                    {
                        writer.Write("application/epub+zip");
                    }
                }
            }

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            if (!File.Exists(outputPath))
            {
                Console.WriteLine("Conversion failed: output file not found.");
                return;
            }

            byte[] hashBytes;
            using (FileStream fs = File.OpenRead(outputPath))
            using (SHA256 sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(fs);
            }

            string computedHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            string expectedHash = "d41d8cd98f00b204e9800998ecf8427e"; // replace with actual checksum

            if (computedHash == expectedHash)
            {
                Console.WriteLine("Output hash matches expected checksum.");
            }
            else
            {
                Console.WriteLine($"Hash mismatch. Computed: {computedHash}, Expected: {expectedHash}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
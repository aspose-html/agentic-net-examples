// Convert EPUB to JPEG and compute SHA256 hash of the output file to verify integrity.

using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string inputPath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(outputDir, "output.jpg");

            if (!File.Exists(inputPath))
            {
                // Create a minimal empty EPUB file (zip archive with .epub extension)
                using (FileStream fs = File.Create(inputPath))
                {
                    // Write minimal ZIP header to avoid format errors
                    byte[] zipHeader = new byte[] { 0x50, 0x4B, 0x05, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    fs.Write(zipHeader, 0, zipHeader.Length);
                }
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            if (File.Exists(outputPath))
            {
                byte[] fileBytes = File.ReadAllBytes(outputPath);
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hash = sha256.ComputeHash(fileBytes);
                    string hashString = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    Console.WriteLine("SHA256: " + hashString);
                }
            }
            else
            {
                Console.WriteLine("Conversion did not produce an output file.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Convert EPUB to JPEG and compute SHA256 hash of the output file to verify integrity.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare directories
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            // Sample EPUB file path
            string epubPath = Path.Combine(dataDir, "sample.epub");
            if (!File.Exists(epubPath))
            {
                // Create a minimal placeholder EPUB file (empty zip structure)
                using (FileStream fs = new FileStream(epubPath, FileMode.Create, FileAccess.Write))
                {
                    // Write minimal ZIP header to avoid immediate format errors
                    byte[] zipHeader = new byte[] { 0x50, 0x4B, 0x05, 0x06 };
                    fs.Write(zipHeader, 0, zipHeader.Length);
                }
            }

            // Output JPEG path
            string outputPath = Path.Combine(outputDir, "output.jpg");

            // Convert EPUB to JPEG
            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            // Compute SHA256 hash of the output file
            byte[] hashBytes;
            using (FileStream outStream = File.OpenRead(outputPath))
            using (SHA256 sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(outStream);
            }

            // Convert hash to hex string
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
                sb.Append(b.ToString("x2"));
            string hashHex = sb.ToString();

            Console.WriteLine("SHA256 hash of the generated JPEG:");
            Console.WriteLine(hashHex);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}
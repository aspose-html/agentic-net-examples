// Convert EPUB to PNG and validate the output by comparing calculated hash with expected value stored in metadata.

using System;
using System.IO;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string epubPath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(outputDir, "output.png");

            if (!File.Exists(epubPath))
            {
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            if (File.Exists(outputPath))
            {
                byte[] pngBytes = File.ReadAllBytes(outputPath);
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(pngBytes);
                    string actualHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                    string expectedHash = "expectedhashvalue";

                    if (actualHash == expectedHash)
                    {
                        Console.WriteLine("Hash validation succeeded.");
                    }
                    else
                    {
                        Console.WriteLine($"Hash validation failed. Expected: {expectedHash}, Actual: {actualHash}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Output PNG not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
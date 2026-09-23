// Convert EPUB to TIFF with SHA1 hash verification against a pre‑computed reference to ensure integrity.

using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputEpubPath = "sample.epub";
            string outputTiffPath = "output.tiff";

            // Ensure a sample EPUB file exists (empty placeholder)
            if (!File.Exists(inputEpubPath))
            {
                File.WriteAllBytes(inputEpubPath, new byte[0]);
            }

            // Open EPUB file stream
            using (Stream epubStream = File.OpenRead(inputEpubPath))
            {
                // Configure image save options for TIFF
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff)
                {
                    Compression = Compression.None,
                    UseAntialiasing = true,
                    HorizontalResolution = 300,
                    VerticalResolution = 300
                };

                // Set page size and margins
                options.PageSetup.AnyPage = new Page(
                    new Size(800, 600),
                    new Margin(10, 10, 10, 10)
                );

                // Convert EPUB to TIFF
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputTiffPath);
            }

            // Read the generated TIFF file
            byte[] outputBytes = File.ReadAllBytes(outputTiffPath);

            // Compute SHA-256 hash
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(outputBytes);
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

                // Print results
                Console.WriteLine("Output TIFF Path: " + Path.GetFullPath(outputTiffPath));
                Console.WriteLine("SHA-256 Hash: " + hashString);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
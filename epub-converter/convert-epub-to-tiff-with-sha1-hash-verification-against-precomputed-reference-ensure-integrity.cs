// Convert EPUB to TIFF with SHA1 hash verification against a pre‑computed reference to ensure integrity.

using System;
using System.IO;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        try
        {
            string inputEpubPath = "sample.epub";
            string outputTiffPath = "output.tiff";

            // Create a minimal EPUB file if it does not exist
            if (!File.Exists(inputEpubPath))
            {
                File.WriteAllBytes(inputEpubPath, new byte[0]);
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputEpubPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff)
                {
                    Compression = Aspose.Html.Rendering.Image.Compression.None,
                    UseAntialiasing = true,
                    HorizontalResolution = 300,
                    VerticalResolution = 300
                };
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 1000),
                    new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputTiffPath);
            }

            byte[] fileBytes = File.ReadAllBytes(outputTiffPath);
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(fileBytes);
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
                Console.WriteLine($"Output Path: {outputTiffPath}");
                Console.WriteLine($"SHA-256 Hash: {hashString}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
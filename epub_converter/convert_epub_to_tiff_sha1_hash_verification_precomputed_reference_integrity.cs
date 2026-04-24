// Convert EPUB to TIFF with SHA1 hash verification against a pre‑computed reference to ensure integrity.

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
            string epubPath = "input.epub";
            string tiffPath = "output.tiff";
            string referenceHash = "YOUR_PRECOMPUTED_SHA1_HASH";

            using (FileStream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                Converter.ConvertEPUB(stream, options, tiffPath);
            }

            using (FileStream fs = File.OpenRead(tiffPath))
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] hashBytes = sha1.ComputeHash(fs);
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

                if (hashString == referenceHash.ToLowerInvariant())
                {
                    Console.WriteLine("SHA1 hash matches reference. Integrity verified.");
                }
                else
                {
                    Console.WriteLine($"SHA1 hash mismatch. Computed: {hashString}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
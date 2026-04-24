// Convert EPUB to JPEG and compute SHA256 hash of the output file to verify integrity.

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
            string jpegPath = "output.jpg";

            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                Converter.ConvertEPUB(epubStream, options, jpegPath);
            }

            using (FileStream jpegStream = File.OpenRead(jpegPath))
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(jpegStream);
                string hashString = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                Console.WriteLine($"SHA256: {hashString}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
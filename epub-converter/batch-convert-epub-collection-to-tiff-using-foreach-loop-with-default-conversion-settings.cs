// Batch convert a collection of EPUB books to TIFF files using a foreach loop and default conversion settings.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample EPUB file paths
            string[] epubFiles = new string[] { "book1.epub", "book2.epub" };

            // Ensure sample EPUB files exist (empty placeholders)
            foreach (string epubPath in epubFiles)
            {
                if (!File.Exists(epubPath))
                {
                    File.WriteAllBytes(epubPath, new byte[0]);
                }
            }

            // Convert each EPUB to TIFF using default settings
            foreach (string epubPath in epubFiles)
            {
                using (Stream epubStream = File.OpenRead(epubPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                    string outputPath = Path.ChangeExtension(epubPath, ".tiff");
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                    Console.WriteLine($"Converted '{epubPath}' to '{outputPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
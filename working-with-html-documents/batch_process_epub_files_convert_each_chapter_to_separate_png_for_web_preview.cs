// Batch process EPUB files, converting each chapter to a separate PNG for web preview.

using System;
using System.IO;
using System.Drawing;
using System.IO.Compression;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input EPUB file (minimal valid EPUB)
            string dataDir = Directory.GetCurrentDirectory();
            string inputPath = Path.Combine(dataDir, "sample.epub");
            if (!File.Exists(inputPath))
            {
                using (FileStream fs = new FileStream(inputPath, FileMode.Create, FileAccess.Write))
                using (ZipArchive zip = new ZipArchive(fs, ZipArchiveMode.Create))
                {
                    // Minimal EPUB structure: mimetype file and a simple HTML content
                    var mimetypeEntry = zip.CreateEntry("mimetype", CompressionLevel.NoCompression);
                    using (var entryStream = mimetypeEntry.Open())
                    using (var writer = new StreamWriter(entryStream))
                    {
                        writer.Write("application/epub+zip");
                    }

                    var contentEntry = zip.CreateEntry("OEBPS/content.html");
                    using (var entryStream = contentEntry.Open())
                    using (var writer = new StreamWriter(entryStream))
                    {
                        writer.Write("<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello EPUB</h1></body></html>");
                    }
                }
            }

            // Prepare output directory
            string outputDir = Path.Combine(dataDir, "output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "page.png");

            // Configure image save options
            ImageSaveOptions options = new ImageSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.UseAntialiasing = true;
            options.BackgroundColor = Color.White;

            // Perform conversion
            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine($"Output image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}
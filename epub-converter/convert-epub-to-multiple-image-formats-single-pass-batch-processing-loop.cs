// Convert an EPUB file to multiple image formats in a single pass using a batch processing loop.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

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
            if (!File.Exists(epubPath))
            {
                // Create a placeholder empty EPUB file
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            using (FileStream stream = File.OpenRead(epubPath))
            {
                var formats = new (ImageFormat format, string extension)[]
                {
                    (ImageFormat.Jpeg, "jpg"),
                    (ImageFormat.Png, "png"),
                    (ImageFormat.Bmp, "bmp"),
                    (ImageFormat.Tiff, "tiff")
                };

                foreach (var fmt in formats)
                {
                    // Reset stream position for each conversion
                    stream.Seek(0, SeekOrigin.Begin);

                    ImageSaveOptions options = new ImageSaveOptions(fmt.format);
                    string outputPath = Path.Combine(outputDir, $"output.{fmt.extension}");
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                    Console.WriteLine($"Converted EPUB to {fmt.extension.ToUpper()} at: {outputPath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
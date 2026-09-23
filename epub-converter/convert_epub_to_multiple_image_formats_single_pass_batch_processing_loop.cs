// Convert an EPUB file to multiple image formats in a single pass using a batch processing loop.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string epubPath = Path.Combine(dataDir, "sample.epub");
            if (!File.Exists(epubPath))
            {
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            var formats = new (Aspose.Html.Rendering.Image.ImageFormat format, string extension)[]
            {
                (Aspose.Html.Rendering.Image.ImageFormat.Jpeg, "jpg"),
                (Aspose.Html.Rendering.Image.ImageFormat.Png, "png"),
                (Aspose.Html.Rendering.Image.ImageFormat.Bmp, "bmp"),
                (Aspose.Html.Rendering.Image.ImageFormat.Tiff, "tiff")
            };

            using (FileStream stream = File.OpenRead(epubPath))
            {
                foreach (var fmt in formats)
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(fmt.format);
                    string outputPath = Path.Combine(outputDir, $"output.{fmt.extension}");
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                    stream.Position = 0;
                }
            }

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
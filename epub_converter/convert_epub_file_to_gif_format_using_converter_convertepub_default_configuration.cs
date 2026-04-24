// Convert an EPUB file to GIF format through Converter.ConvertEPUB using the library’s default configuration.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = Path.Combine("output", "sample.gif");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            using (FileStream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                Converter.ConvertEPUB(stream, options, outputPath);
            }
            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
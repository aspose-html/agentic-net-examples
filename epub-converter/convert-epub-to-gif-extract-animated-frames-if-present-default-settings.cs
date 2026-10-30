// Convert an EPUB file to GIF image extracting animated frames if present using default settings.

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
            string inputPath = "sample.epub";
            string outputDirectory = "output";
            Directory.CreateDirectory(outputDirectory);
            string outputPath = Path.Combine(outputDirectory, "output.gif");

            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to GIF. Output saved at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
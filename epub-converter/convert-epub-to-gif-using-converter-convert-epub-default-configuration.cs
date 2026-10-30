// Convert an EPUB file to GIF format through Converter.ConvertEPUB using the library’s default configuration.

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
            string outputPath = "output.gif";

            using (Stream epubStream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
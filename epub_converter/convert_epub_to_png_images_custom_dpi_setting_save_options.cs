// Convert an EPUB file to PNG images with a custom DPI setting via appropriate save options.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string epubPath = "sample.epub";
            string outputPath = "output.png";
            using (FileStream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions();
                options.HorizontalResolution = 400;
                options.VerticalResolution = 400;
                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
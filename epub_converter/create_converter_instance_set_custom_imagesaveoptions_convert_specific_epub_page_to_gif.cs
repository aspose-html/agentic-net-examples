// Create a Converter instance, set custom ImageSaveOptions, and convert a specific EPUB page to GIF.

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
            string epubPath = "input.epub";
            string outputPath = "output.gif";

            using (FileStream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
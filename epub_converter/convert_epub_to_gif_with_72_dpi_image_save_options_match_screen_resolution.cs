// Convert EPUB to GIF while applying 72 DPI setting in ImageSaveOptions to match screen resolution.

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
            using (FileStream stream = File.OpenRead("input.epub"))
            {
                string outputPath = "output.gif";
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                options.HorizontalResolution = 72;
                options.VerticalResolution = 72;
                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Convert EPUB to GIF and set ImageSaveOptions.BackgroundColor to black for dark‑mode compatible animation.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.epub";
            string outputPath = "output.gif";

            using (FileStream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                options.BackgroundColor = Color.Black;
                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
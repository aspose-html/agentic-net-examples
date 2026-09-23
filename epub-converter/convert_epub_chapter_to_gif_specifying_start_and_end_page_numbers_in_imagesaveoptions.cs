// Convert an EPUB chapter to a GIF by specifying start and end page numbers in ImageSaveOptions.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            if (!File.Exists(inputPath))
            {
                // Create a minimal empty EPUB file as placeholder
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            FileStream stream = File.OpenRead(inputPath);
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.gif");

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            Page page = new Page(
                new Size(800, 600),
                new Margin(0, 0, 0, 0));
            options.PageSetup.AnyPage = page;

            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            stream.Close();

            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
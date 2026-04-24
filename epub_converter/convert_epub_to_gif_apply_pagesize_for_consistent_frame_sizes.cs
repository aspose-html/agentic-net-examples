// Convert EPUB to GIF and apply ImageSaveOptions.PageSize to achieve consistent frame sizes.

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
            using (FileStream stream = File.OpenRead("input.epub"))
            {
                string outputPath = "output.gif";

                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 400;
                options.VerticalResolution = 400;

                Page page = new Page(new Size(800, 500), new Margin(30, 20, 10, 10));
                options.PageSetup.AnyPage = page;

                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
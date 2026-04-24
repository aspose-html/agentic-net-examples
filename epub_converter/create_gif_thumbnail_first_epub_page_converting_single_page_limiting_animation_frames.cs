// Create a GIF thumbnail of the first EPUB page by converting a single page and limiting animation frames.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Open the EPUB file as a readable stream
            using (FileStream stream = File.OpenRead("sample.epub"))
            {
                // Destination path for the GIF thumbnail
                string outputPath = "thumbnail.gif";

                // Configure image save options for GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                options.UseAntialiasing = true;               // Improve visual quality
                options.HorizontalResolution = 300;           // Set horizontal DPI
                options.VerticalResolution = 300;             // Set vertical DPI

                // Define page size and margins (first page rendering)
                Page page = new Page(new Size(800, 500), new Margin(30, 20, 10, 10));
                options.PageSetup.AnyPage = page;

                // Convert the EPUB stream to a GIF image (first page rendered)
                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
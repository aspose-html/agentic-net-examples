// Convert EPUB to BMP and set ImageSaveOptions.PageSize to match desired output dimensions.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input EPUB and output BMP
            string epubPath = "input.epub";
            string outputPath = "output.bmp";

            // Open the EPUB file as a stream
            using (Stream stream = File.OpenRead(epubPath))
            {
                // Create image save options for BMP format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                // Define the desired page size (width x height)
                Page page = new Page(new Size(800, 500)); // size in points

                // Apply the page size to the options
                options.PageSetup.AnyPage = page;

                // Convert the EPUB to BMP using the configured options
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Configure ImageSaveOptions to use a transparent background when converting EPUB content to GIF images.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Open the EPUB file as a readable stream
            using (FileStream stream = File.OpenRead("input.epub"))
            {
                // Define the output GIF file path
                string outputPath = "output.gif";

                // Create ImageSaveOptions for GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // Set transparent background
                options.BackgroundColor = Color.Transparent;

                // Convert EPUB to GIF with the configured options
                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
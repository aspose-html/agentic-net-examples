// Convert EPUB to GIF using ImageSaveOptions.CssMediaType='screen' to reflect screen‑based CSS rules during rendering.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source EPUB file
            string epubPath = "input.epub";
            // Desired output GIF file path
            string outputPath = "output.gif";

            // Open the EPUB file as a readable stream
            using (Stream stream = File.OpenRead(epubPath))
            {
                // Create ImageSaveOptions specifying GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                // Apply screen‑based CSS rules during rendering
                options.Css.MediaType = MediaType.Screen;

                // Perform the conversion from EPUB to GIF
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to GIF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}
// Export MHTML to GIF format with transparent background support using ImageSaveOptions settings.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source MHTML file
            string sourcePath = "input.mhtml";
            // Desired output GIF file path
            string outputPath = "output.gif";

            // Open the MHTML file as a stream
            using (Stream stream = File.OpenRead(sourcePath))
            {
                // Configure image saving options for GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                // Set transparent background for the GIF
                options.BackgroundColor = Color.Transparent;

                // Convert MHTML to GIF using Aspose.HTML
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("MHTML successfully converted to GIF with transparent background.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}
// Transform MHTML content into a high‑resolution PNG image using ImageSaveOptions with DPI settings.

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
            // Open the MHTML file as a stream
            using (Stream stream = File.OpenRead("input.mhtml"))
            {
                // Destination PNG file path
                string outputPath = "output.png";

                // Configure image save options for PNG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                // Set high resolution (DPI) for the output image
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Convert MHTML to PNG using the configured options
                Converter.ConvertMHTML(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
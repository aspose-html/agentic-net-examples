// Render an MHTML document to JPG with 300 DPI resolution and white background for print‑ready images.

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
            string inputPath = "input.mhtml";
            string outputPath = "output.jpg";

            // Open the MHTML file as a stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Create ImageSaveOptions for JPEG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Set DPI resolution
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Set white background for print‑ready image
                options.BackgroundColor = Color.White;

                // Convert MHTML to JPEG
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
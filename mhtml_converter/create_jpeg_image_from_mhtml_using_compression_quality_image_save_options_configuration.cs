// Create a JPEG image from MHTML by applying compression quality through ImageSaveOptions configuration.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source MHTML file
            string inputPath = "input.mhtml";
            // Desired output JPEG file path
            string outputPath = "output.jpg";

            // Open the MHTML file as a readable stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Create image save options for JPEG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                // Optional rendering settings
                options.UseAntialiasing = true;
                // options.HorizontalResolution = 96;
                // options.VerticalResolution = 96;

                // Convert MHTML to JPEG using the configured options
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("MHTML successfully converted to JPEG.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}
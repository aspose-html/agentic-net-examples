// Configure ImageSaveOptions to set JPEG subsampling factor for optimized file size during MHTML conversion.

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
            // Path to the source MHTML file
            string sourcePath = "input.mhtml";
            // Path where the JPEG image will be saved
            string outputPath = "output.jpg";

            // Open the source MHTML as a readable stream
            using (Stream stream = File.OpenRead(sourcePath))
            {
                // Create ImageSaveOptions with JPEG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // JPEG subsampling factor is not supported by Aspose.HTML in this environment,
                // so we cannot set it. Instead, we can configure other validated properties.
                options.UseAntialiasing = true;
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                // Convert MHTML to JPEG image
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
// Export MHTML to GIF format with transparent background support using ImageSaveOptions settings.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.gif";

            // Open the source MHTML file
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for GIF with transparent background
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                options.BackgroundColor = Color.Transparent;

                // Convert MHTML to GIF
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
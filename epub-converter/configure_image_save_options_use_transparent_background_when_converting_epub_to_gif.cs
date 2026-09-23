// Configure ImageSaveOptions to use a transparent background when converting EPUB content to GIF images.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path
            string inputPath = "sample.epub";
            // Output GIF file path
            string outputPath = "output.gif";

            // Open the EPUB file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for GIF with transparent background
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                options.BackgroundColor = System.Drawing.Color.Transparent;

                // Convert EPUB to GIF
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}
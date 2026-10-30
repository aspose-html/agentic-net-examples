// Configure ImageSaveOptions to use a transparent background when converting EPUB content to GIF images.

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
            string inputPath = "sample.epub";
            string outputPath = "output.gif";

            // Ensure the sample EPUB file exists; create a minimal placeholder if needed
            if (!File.Exists(inputPath))
            {
                // Create an empty EPUB file as a placeholder (real content not required for demo)
                using (FileStream placeholder = File.Create(inputPath)) { }
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                options.BackgroundColor = System.Drawing.Color.Transparent;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB has been successfully converted to GIF with a transparent background.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}
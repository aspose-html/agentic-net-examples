// Generate a multi‑page TIFF from a single MHTML file by setting ImageSaveOptions multipage flag.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.tiff";

            using (Stream stream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                // Optional: set resolution
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                Console.WriteLine("MHTML has been successfully converted to multi-page TIFF (if applicable).");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
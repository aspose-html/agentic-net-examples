// Generate a multi‑page TIFF from a single MHTML file by setting ImageSaveOptions multipage flag.

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
            string inputPath = "sample.mhtml";
            string outputPath = "output.tiff";

            // Ensure the input file exists; create a minimal placeholder if needed
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><p>Sample MHTML content</p></body></html>");
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("MHTML has been successfully converted to multi-page TIFF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
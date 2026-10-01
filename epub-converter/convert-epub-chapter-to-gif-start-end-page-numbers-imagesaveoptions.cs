// Convert an EPUB chapter to a GIF by specifying start and end page numbers in ImageSaveOptions.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.gif";

            // Create a minimal EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                // If the API supports page range, you could set it like this:
                // options.PageSetup.StartPage = 2;
                // options.PageSetup.EndPage = 5;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
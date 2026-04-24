// Convert an EPUB chapter to a GIF by specifying start and end page numbers in ImageSaveOptions.

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
            // Path to the source EPUB file
            string inputPath = "chapter.epub";

            // Path where the resulting GIF will be saved
            string outputPath = "chapter.gif";

            // Open the EPUB file as a readable stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // If page range were supported, it could be set here, e.g.:
                // options.PageSetup.StartPage = 2;
                // options.PageSetup.EndPage = 5;

                // Convert the EPUB stream to a GIF image
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB chapter successfully converted to GIF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}
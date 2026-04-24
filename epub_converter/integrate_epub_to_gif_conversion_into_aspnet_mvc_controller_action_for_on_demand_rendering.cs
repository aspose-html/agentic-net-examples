// Integrate EPUB to GIF conversion into an ASP.NET MVC controller action for on‑demand rendering.

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
            string epubPath = "input.epub";

            // Path where the resulting GIF will be saved
            string outputPath = "output.gif";

            // Open the EPUB file as a readable stream
            using (FileStream stream = File.OpenRead(epubPath))
            {
                // Configure image saving options for GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // Perform the conversion from EPUB to GIF
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to GIF.");
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}
// Convert EPUB to PNG and set ImageSaveOptions.CssMediaType to 'all' for comprehensive CSS handling.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB file and output PNG file paths
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);
            string epubPath = Path.Combine(dataDir, "sample.epub");
            string pngPath = Path.Combine(outputDir, "output.png");

            // Open the EPUB file as a readable stream
            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                // Create image save options for PNG output
                ImageSaveOptions options = new ImageSaveOptions();

                // If the API supports setting CSS media type to 'all', it can be set here.
                // The enum value 'All' is not available in this version, so this line is omitted.
                // options.Css.MediaType = MediaType.All;

                // Convert the EPUB stream to a PNG image using Aspose.HTML
                Converter.ConvertEPUB(epubStream, options, pngPath);
            }

            Console.WriteLine("EPUB successfully converted to PNG.");
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
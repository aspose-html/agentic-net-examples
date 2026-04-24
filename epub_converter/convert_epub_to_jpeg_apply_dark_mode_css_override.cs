// Convert EPUB to JPEG while applying a dark‑mode CSS override via ImageSaveOptions.CssMediaType='screen'.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output directories
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            // Open the EPUB file as a stream
            using (Stream epubStream = File.OpenRead(Path.Combine(dataDir, "sample.epub")))
            {
                // Create image save options for JPEG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Apply dark‑mode CSS override by using screen media type
                options.Css.MediaType = MediaType.Screen;

                // Define the output JPEG file path
                string outputPath = Path.Combine(outputDir, "result.jpg");

                // Convert the EPUB to JPEG with the specified options
                Converter.ConvertEPUB(epubStream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
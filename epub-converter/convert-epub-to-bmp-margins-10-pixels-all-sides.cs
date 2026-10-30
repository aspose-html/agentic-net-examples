// Convert EPUB to BMP with ImageSaveOptions.Margins set to 10 pixels on all sides.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path
            string inputPath = "sample.epub";
            // Output BMP file path
            string outputPath = "output.bmp";

            // Ensure the input file exists (create a placeholder if necessary)
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            // Open the EPUB file stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Create image save options for BMP format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                // Define page size (optional) and margins of 10 pixels on all sides
                Page page = new Page(
                    new Size(800, 600),
                    new Margin(10, 10, 10, 10)
                );
                options.PageSetup.AnyPage = page;

                // Convert EPUB to BMP
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
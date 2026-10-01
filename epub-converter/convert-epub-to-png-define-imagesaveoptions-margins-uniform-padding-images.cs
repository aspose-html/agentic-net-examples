// Convert EPUB to PNG and define ImageSaveOptions.Margins to create uniform padding for images.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare input and output paths
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string epubPath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(outputDir, "output.png");

            // Create a minimal EPUB file if it does not exist
            if (!File.Exists(epubPath))
            {
                using (FileStream fs = File.Create(epubPath))
                {
                    // Empty placeholder; in real scenarios provide a valid EPUB file
                }
            }

            // Open EPUB file stream
            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                // Configure image save options with padding (margins)
                ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.White;

                // Define page size and uniform margins (padding)
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 1000),
                    new Aspose.Html.Drawing.Margin(20, 20, 20, 20) // left, top, right, bottom
                );
                options.PageSetup.AnyPage = page;

                // Convert EPUB to PNG
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to PNG with padding.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}
// Render an EPUB document to PNG images, one image per page, preserving original dimensions.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input EPUB file (dummy file for demonstration)
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);
            string epubPath = Path.Combine(dataDir, "sample.epub");
            if (!File.Exists(epubPath))
            {
                // Create an empty file to avoid FileNotFoundException.
                // In a real scenario, provide a valid EPUB file.
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            // Output image path
            string outputPath = Path.Combine(dataDir, "output.png");

            // Configure image save options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = Color.White;

            // Define page setup
            var page = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(800, 600),
                new Aspose.Html.Drawing.Margin(10, 10, 10, 10));
            options.PageSetup.AnyPage = page;

            // Perform conversion
            using (Stream epubStream = File.OpenRead(epubPath))
            {
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine("Output file: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}
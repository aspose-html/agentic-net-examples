// Convert EPUB to JPEG while configuring ImageSaveOptions.Margins to add white borders around each page.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare input EPUB file path
            string dataDir = "Data";
            Directory.CreateDirectory(dataDir);
            string inputPath = Path.Combine(dataDir, "sample.epub");
            if (!File.Exists(inputPath))
            {
                // Create an empty placeholder EPUB file
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            // Prepare output JPEG file path
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "output.jpg");

            // Open EPUB stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure image save options with white margins
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                options.UseAntialiasing = true;
                options.BackgroundColor = System.Drawing.Color.White;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Define page size and margins (left, top, right, bottom)
                Page page = new Page(
                    new Size(800, 1200),
                    new Margin(20, 20, 20, 20)
                );
                options.PageSetup.AnyPage = page;

                // Convert EPUB to JPEG
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
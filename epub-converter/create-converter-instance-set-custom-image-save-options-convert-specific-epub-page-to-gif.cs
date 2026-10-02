// Create a Converter instance, set custom ImageSaveOptions, and convert a specific EPUB page to GIF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file (ensure this file exists in the working directory)
            string inputPath = "sample.epub";

            // Prepare output directory and file path
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "page1.gif");

            // Open the EPUB file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for GIF format
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Optional: set page size for any page
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 600),
                    new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

                // Convert the EPUB to GIF
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB page converted to GIF successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
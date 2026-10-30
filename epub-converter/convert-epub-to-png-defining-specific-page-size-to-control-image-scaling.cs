// Convert EPUB to PNG with ImageSaveOptions defining a specific page size to control image scaling.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path (ensure this file exists)
            string inputPath = "sample.epub";
            // Output folder for PNG images
            string outputFolder = "output";

            // Create output directory if it does not exist
            Directory.CreateDirectory(outputFolder);

            // Open EPUB file stream
            using (Stream epubStream = File.OpenRead(inputPath))
            {
                // Configure image save options with specific page size and resolution
                ImageSaveOptions options = new ImageSaveOptions();
                // Set page size (e.g., 800x600 pixels)
                Page page = new Page();
                page.Size = new Size(Length.FromPixels(800), Length.FromPixels(600));
                options.PageSetup.AnyPage = page;
                // Set resolution
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Convert EPUB to PNG images
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputFolder);
            }

            Console.WriteLine("EPUB conversion to PNG completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during EPUB to PNG conversion: " + ex.Message);
        }
    }
}
// Convert EPUB to JPEG with ImageSaveOptions.DpiX and DpiY set to 300 for high‑resolution output.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB file and output JPEG file paths
            string inputPath = "sample.epub";
            string outputPath = "output.jpg";

            // Ensure the input file exists (create an empty placeholder if necessary)
            if (!File.Exists(inputPath))
            {
                using (FileStream placeholder = File.Create(inputPath))
                {
                    // No content needed for placeholder
                }
            }

            // Open the EPUB file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for high‑resolution JPEG
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.UseAntialiasing = true;
                options.BackgroundColor = Color.White;

                // Convert EPUB to JPEG
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}
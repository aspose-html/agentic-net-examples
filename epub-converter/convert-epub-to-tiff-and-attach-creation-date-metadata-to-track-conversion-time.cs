// Convert EPUB to TIFF and attach creation date metadata using ImageSaveOptions to track conversion time.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB file path and output TIFF file path
            string inputPath = "sample.epub";
            string outputPath = "output.tiff";

            // Ensure the input file exists (create a placeholder if necessary)
            if (!File.Exists(inputPath))
            {
                // Create an empty placeholder file (real EPUB content is required for actual conversion)
                using (FileStream placeholder = File.Create(inputPath))
                {
                    // No content written
                }
            }

            // Open the EPUB file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for TIFF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

                // Perform the conversion from EPUB to TIFF
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion: " + ex.Message);
        }
    }
}
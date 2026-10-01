// Convert an EPUB file to JPG images using default settings, saving each page as a separate file.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input EPUB file and output directory
            string dataDir = "Data";
            string inputFile = Path.Combine(dataDir, "sample.epub");
            string outputDir = "Output";

            // Ensure directories exist
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            // If the sample EPUB does not exist, create an empty placeholder (for demonstration)
            if (!File.Exists(inputFile))
            {
                using (FileStream placeholder = File.Create(inputFile))
                {
                    // Write minimal EPUB header bytes (optional, can be left empty)
                }
            }

            // Open the EPUB file stream
            using (FileStream stream = File.OpenRead(inputFile))
            {
                // Create image save options for JPEG format (default settings)
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Define output file pattern; each page will be saved as a separate JPEG file
                string outputPath = Path.Combine(outputDir, "page.jpg");

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB conversion to JPEG images completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}
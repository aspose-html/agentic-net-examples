// Convert EPUB to JPEG and embed custom EXIF author metadata using ImageSaveOptions before saving.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output directories
            string dataDir = "DataDir";
            string outputDir = "OutputDir";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Path to the source EPUB file
            string epubPath = Path.Combine(dataDir, "sample.epub");

            // Path for the resulting JPEG image
            string outputPath = Path.Combine(outputDir, "output.jpg");

            // Open a read-only stream for the EPUB file
            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                // Configure image save options for JPEG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // NOTE: Aspose.HTML ImageSaveOptions does not expose EXIF metadata properties.
                // Therefore, embedding custom EXIF author metadata is not supported in this context.

                // Convert the EPUB to a JPEG image and save to the specified path
                Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to JPEG at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
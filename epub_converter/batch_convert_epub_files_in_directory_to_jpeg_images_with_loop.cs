// Batch convert all EPUB files in a directory to JPEG images using a loop over Converter.ConvertEPUB.

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
            // Input folder containing EPUB files
            string inputFolder = @"C:\InputEpubs";
            // Output folder for JPEG images
            string outputFolder = @"C:\OutputJpegs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all EPUB files in the input folder
            foreach (string epubPath in Directory.GetFiles(inputFolder, "*.epub"))
            {
                // Prepare the output JPEG file path
                string outputPath = Path.Combine(
                    outputFolder,
                    Path.GetFileNameWithoutExtension(epubPath) + ".jpg");

                // Open the EPUB file as a read-only stream
                using (FileStream stream = File.OpenRead(epubPath))
                {
                    // Configure image save options for JPEG format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                    // Convert the EPUB stream to a JPEG image
                    Converter.ConvertEPUB(stream, options, outputPath);
                }
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
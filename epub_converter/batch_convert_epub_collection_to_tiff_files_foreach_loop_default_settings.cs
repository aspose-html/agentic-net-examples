// Batch convert a collection of EPUB books to TIFF files using a foreach loop and default conversion settings.

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
            // Define the folder containing EPUB files
            string inputFolder = @"C:\Epubs";
            // Define the folder where TIFF files will be saved
            string outputFolder = @"C:\TiffOutputs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all EPUB files in the input folder
            string[] epubFiles = Directory.GetFiles(inputFolder, "*.epub");

            // Iterate over each EPUB file
            foreach (string epubPath in epubFiles)
            {
                // Open the EPUB file as a readable stream
                using (Stream stream = File.OpenRead(epubPath))
                {
                    // Create image save options with TIFF format (default settings)
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);

                    // Determine the output TIFF file path
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(epubPath);
                    string tiffPath = Path.Combine(outputFolder, fileNameWithoutExt + ".tiff");

                    // Convert the EPUB to a TIFF image using default settings
                    Converter.ConvertEPUB(stream, options, tiffPath);
                }
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
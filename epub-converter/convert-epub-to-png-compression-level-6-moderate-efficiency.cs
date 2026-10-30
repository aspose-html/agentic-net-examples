// Convert EPUB to PNG using ImageSaveOptions.CompressionLevel set to 6 for moderate compression efficiency.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace AsposeHtmlEpubToPng
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Prepare input and output directories
                string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
                Directory.CreateDirectory(dataDir);
                Directory.CreateDirectory(outputDir);

                // Path to the sample EPUB file (create a placeholder if it does not exist)
                string epubPath = Path.Combine(dataDir, "sample.epub");
                if (!File.Exists(epubPath))
                {
                    // Create an empty file as a placeholder EPUB.
                    // In a real scenario, replace this with a valid EPUB file.
                    File.WriteAllBytes(epubPath, new byte[0]);
                }

                // Output PNG file path
                string outputPath = Path.Combine(outputDir, "output.png");

                // Open the EPUB file stream
                using (FileStream epubStream = File.OpenRead(epubPath))
                {
                    // Configure image save options (default format is PNG)
                    ImageSaveOptions options = new ImageSaveOptions();
                    // Note: CompressionLevel property is not available in the API, so it is omitted.

                    // Perform the conversion
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                }

                Console.WriteLine("EPUB has been successfully converted to PNG:");
                Console.WriteLine(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during conversion:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
// Convert EPUB to PNG and implement IProgress interface to receive real‑time updates from the conversion process.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path
            string inputPath = "sample.epub";
            // Output PNG file path
            string outputPath = "output.png";

            // Open the EPUB file stream
            using (Stream inputStream = File.OpenRead(inputPath))
            {
                // Configure image save options
                ImageSaveOptions options = new ImageSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(inputStream, options, outputPath);
            }

            Console.WriteLine("EPUB to PNG conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
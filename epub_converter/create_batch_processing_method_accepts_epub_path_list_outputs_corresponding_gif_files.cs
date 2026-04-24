// Create a batch processing method that accepts a list of EPUB paths and outputs corresponding GIF files.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Example list of EPUB files; replace with actual paths or obtain from args
            var epubFiles = new List<string>
            {
                @"C:\Input\book1.epub",
                @"C:\Input\book2.epub"
            };

            // Output directory for GIF files
            string outputDir = @"C:\Output";

            BatchConvertEpubToGif(epubFiles, outputDir);
            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Converts each EPUB file in the list to a GIF image saved in the specified output directory.
    static void BatchConvertEpubToGif(List<string> epubPaths, string outputDirectory)
    {
        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        foreach (var epubPath in epubPaths)
        {
            // Validate input file existence
            if (!File.Exists(epubPath))
            {
                Console.WriteLine($"File not found: {epubPath}");
                continue;
            }

            // Determine output GIF file path (same name with .gif extension)
            string outputFileName = Path.GetFileNameWithoutExtension(epubPath) + ".gif";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Open the EPUB file as a readable stream and perform conversion
            using (FileStream stream = File.OpenRead(epubPath))
            {
                // Configure image save options for GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // Convert EPUB stream to GIF image
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine($"Converted '{epubPath}' to '{outputPath}'.");
        }
    }
}
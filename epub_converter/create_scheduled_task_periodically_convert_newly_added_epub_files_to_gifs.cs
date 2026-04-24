// Create a scheduled task that periodically converts newly added EPUB files in a directory to GIFs.

using System;
using System.IO;
using System.Threading;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Directory where new EPUB files are placed
            string inputDirectory = @"C:\EpubInput";
            // Directory where converted GIFs will be saved
            string outputDirectory = @"C:\GifOutput";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Interval for periodic scanning (e.g., every 5 minutes)
            TimeSpan scanInterval = TimeSpan.FromMinutes(5);

            // Set up a timer that triggers the conversion process at the defined interval
            Timer timer = new Timer(state => ProcessNewEpubFiles(inputDirectory, outputDirectory),
                                    null,
                                    TimeSpan.Zero,
                                    scanInterval);

            Console.WriteLine("EPUB to GIF conversion service is running. Press Enter to stop.");
            Console.ReadLine(); // Keep the application alive until user decides to exit
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unhandled exception: {ex.Message}");
        }
    }

    // Scans the input folder for EPUB files that have not yet been converted
    static void ProcessNewEpubFiles(string inputDir, string outputDir)
    {
        foreach (string epubPath in Directory.GetFiles(inputDir, "*.epub"))
        {
            string baseName = Path.GetFileNameWithoutExtension(epubPath);
            string gifPath = Path.Combine(outputDir, baseName + ".gif");

            // Skip conversion if the GIF already exists
            if (File.Exists(gifPath))
                continue;

            // Open the EPUB file as a readable stream
            using (FileStream stream = File.OpenRead(epubPath))
            {
                // Configure the conversion to produce a GIF image
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // Perform the conversion using Aspose.HTML
                Converter.ConvertEPUB(stream, options, gifPath);
            }

            Console.WriteLine($"Converted '{epubPath}' to '{gifPath}'.");
        }
    }
}
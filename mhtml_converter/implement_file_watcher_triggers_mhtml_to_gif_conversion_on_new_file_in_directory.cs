// Implement a file watcher that triggers MHTML to GIF conversion whenever a new file appears in a directory.

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
            // Directory to monitor for new MHTML files
            string inputDirectory = @"C:\Input";
            // Directory where the resulting GIF files will be saved
            string outputDirectory = @"C:\Output";

            var watcher = new FileSystemWatcher(inputDirectory)
            {
                Filter = "*.mhtml",
                EnableRaisingEvents = true,
                IncludeSubdirectories = false
            };

            watcher.Created += (sender, e) =>
            {
                try
                {
                    // Small delay to ensure the file is fully written
                    System.Threading.Thread.Sleep(500);

                    string sourcePath = e.FullPath;
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(sourcePath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".gif");

                    // Open the MHTML file as a stream
                    System.IO.FileStream stream = System.IO.File.OpenRead(sourcePath);
                    // Configure image saving options for GIF format
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                    // Perform the conversion from MHTML to GIF
                    Converter.ConvertMHTML(stream, options, outputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file '{e.Name}': {ex.Message}");
                }
            };

            Console.WriteLine("Watching for new MHTML files. Press Enter to exit.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}
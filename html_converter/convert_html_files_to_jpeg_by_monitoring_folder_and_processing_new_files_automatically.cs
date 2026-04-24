// Convert HTML files to JPEG by monitoring a folder and processing new files automatically.

using System;
using System.IO;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Folder paths (adjust as needed)
            string inputFolder = "InputHtml";
            string outputFolder = "OutputJpeg";

            // Ensure output folder exists
            Directory.CreateDirectory(outputFolder);

            // Process any existing HTML files
            ProcessFolder(inputFolder, outputFolder);

            // Set up a watcher to monitor new HTML files
            using (var watcher = new FileSystemWatcher(inputFolder, "*.html"))
            {
                watcher.Created += (sender, e) =>
                {
                    // Small delay to allow the file to be fully written
                    Thread.Sleep(500);
                    ProcessFile(e.FullPath, outputFolder);
                };
                watcher.EnableRaisingEvents = true;

                Console.WriteLine("Monitoring folder for new HTML files. Press Enter to exit.");
                Console.ReadLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Convert all HTML files in a folder to JPEG
    static void ProcessFolder(string inputFolder, string outputFolder)
    {
        foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
        {
            ProcessFile(htmlPath, outputFolder);
        }
    }

    // Convert a single HTML file to JPEG
    static void ProcessFile(string htmlPath, string outputFolder)
    {
        using (HTMLDocument document = new HTMLDocument(htmlPath))
        {
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            string outputPath = Path.Combine(outputFolder,
                Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
            Converter.ConvertHTML(document, options, outputPath);
        }
    }
}
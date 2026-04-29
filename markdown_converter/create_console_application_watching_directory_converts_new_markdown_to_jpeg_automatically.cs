// Create a console application that watches a directory and converts new Markdown files to JPEG automatically.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        string inputFolder = @"C:\MarkdownInput";
        string outputFolder = @"C:\JpegOutput";

        Directory.CreateDirectory(outputFolder);

        using var watcher = new FileSystemWatcher(inputFolder, "*.md")
        {
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime,
            EnableRaisingEvents = true
        };

        watcher.Created += (s, e) =>
        {
            try
            {
                // Ensure the file is ready for reading
                using var stream = new FileStream(e.FullPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                stream.Close();

                // Convert markdown to HTMLDocument
                HTMLDocument document = Converter.ConvertMarkdown(e.FullPath);

                // Prepare JPEG rendering options
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Determine output JPEG path
                string outputPath = Path.Combine(outputFolder,
                    Path.GetFileNameWithoutExtension(e.FullPath) + ".jpg");

                // Render HTMLDocument to JPEG
                Converter.ConvertHTML(document, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing file '{e.Name}': {ex.Message}");
            }
        };

        Console.WriteLine("Watching for new markdown files. Press Enter to exit.");
        Console.ReadLine();
    }
}
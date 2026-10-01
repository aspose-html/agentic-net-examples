// Parallel convert a collection of EPUB documents to BMP images with concurrent tasks to reduce overall runtime.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB files (hardcoded for the example)
            string[] epubFiles = new string[]
            {
                "sample1.epub",
                "sample2.epub",
                "sample3.epub"
            };

            // Ensure sample EPUB files exist (empty placeholders)
            foreach (string epubPath in epubFiles)
            {
                if (!File.Exists(epubPath))
                {
                    using (FileStream fs = File.Create(epubPath))
                    {
                        // Create an empty file as placeholder
                    }
                }
            }

            // Prepare output base directory
            string outputBase = "output";
            if (!Directory.Exists(outputBase))
            {
                Directory.CreateDirectory(outputBase);
            }

            // List to hold conversion tasks
            List<Task> tasks = new List<Task>();

            foreach (string epubPath in epubFiles)
            {
                tasks.Add(Task.Run(() =>
                {
                    // Create a unique output folder for each EPUB
                    string outputFolder = Path.Combine(outputBase, Path.GetFileNameWithoutExtension(epubPath));
                    if (!Directory.Exists(outputFolder))
                    {
                        Directory.CreateDirectory(outputFolder);
                    }

                    // Open the EPUB file as a stream
                    using (Stream epubStream = File.OpenRead(epubPath))
                    {
                        // Set image save options to BMP format
                        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                        // Convert EPUB to BMP images, each page will be saved in the output folder
                        Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputFolder);
                    }
                }));
            }

            // Wait for all conversions to complete
            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("All EPUB files have been converted to BMP images.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
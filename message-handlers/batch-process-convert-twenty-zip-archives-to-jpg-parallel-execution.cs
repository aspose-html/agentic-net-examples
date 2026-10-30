// Create a batch process that converts twenty ZIP archives to JPG with parallel execution.

using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample ZIP files (20 archives, each containing a simple HTML file)
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "input_zips");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "output_images");
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            List<string> zipPaths = new List<string>();
            for (int i = 1; i <= 20; i++)
            {
                string zipPath = Path.Combine(inputFolder, $"sample{i}.zip");
                using (FileStream zipToCreate = new FileStream(zipPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry htmlEntry = archive.CreateEntry("page.html");
                    using (StreamWriter writer = new StreamWriter(htmlEntry.Open()))
                    {
                        writer.Write("<!DOCTYPE html><html><body><h1>Sample Document " + i + "</h1></body></html>");
                    }
                }
                zipPaths.Add(zipPath);
            }

            // Parallel processing of ZIP archives
            Parallel.ForEach(zipPaths, zipPath =>
            {
                try
                {
                    using (FileStream zipStream = new FileStream(zipPath, FileMode.Open, FileAccess.Read))
                    using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase))
                            {
                                // Extract HTML entry to a temporary file
                                string tempHtmlPath = Path.GetTempFileName();
                                using (FileStream tempFile = new FileStream(tempHtmlPath, FileMode.Create, FileAccess.Write))
                                using (Stream entryStream = entry.Open())
                                {
                                    entryStream.CopyTo(tempFile);
                                }

                                // Prepare output JPG path
                                string jpgFileName = Path.GetFileNameWithoutExtension(zipPath) + "_" + Path.GetFileNameWithoutExtension(entry.FullName) + ".jpg";
                                string jpgOutputPath = Path.Combine(outputFolder, jpgFileName);

                                // Set image save options for JPEG
                                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                                // Convert HTML to JPEG
                                Aspose.Html.Converters.Converter.ConvertHTML(tempHtmlPath, options, jpgOutputPath);

                                // Clean up temporary HTML file
                                File.Delete(tempHtmlPath);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing ZIP '{zipPath}': {ex.Message}");
                }
            });

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}
// Create a batch process that converts twenty ZIP archives to JPG with parallel execution.

using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace ZipToJpgBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input directory containing ZIP archives
                string inputDirectory = @"C:\InputZips";
                // Output directory for generated JPG files
                string outputDirectory = @"C:\OutputJpgs";

                Directory.CreateDirectory(outputDirectory);

                // Get first 20 ZIP files
                var zipFiles = Directory.GetFiles(inputDirectory, "*.zip")
                                         .Take(20)
                                         .ToArray();

                // Process each ZIP in parallel
                Parallel.ForEach(zipFiles, zipPath =>
                {
                    try
                    {
                        // Open the ZIP archive
                        using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                        {
                            // Find the first HTML file inside the archive
                            var htmlEntry = archive.Entries
                                                   .FirstOrDefault(e => e.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase));

                            if (htmlEntry == null)
                                return; // No HTML to convert

                            // Extract HTML entry to a temporary file
                            string tempHtmlPath = Path.Combine(Path.GetTempPath(),
                                Guid.NewGuid().ToString() + ".html");

                            using (var entryStream = htmlEntry.Open())
                            using (var tempFileStream = File.Create(tempHtmlPath))
                            {
                                entryStream.CopyTo(tempFileStream);
                            }

                            // Prepare conversion options for JPEG
                            var options = new ImageSaveOptions(ImageFormat.Jpeg);

                            // Define output JPG file name based on ZIP name
                            string outputJpgPath = Path.Combine(outputDirectory,
                                Path.GetFileNameWithoutExtension(zipPath) + ".jpg");

                            // Convert the extracted HTML to JPEG
                            Converter.ConvertHTML(tempHtmlPath, options, outputJpgPath);

                            // Clean up temporary HTML file
                            File.Delete(tempHtmlPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle individual ZIP conversion errors
                        Console.WriteLine($"Error processing '{zipPath}': {ex.Message}");
                    }
                });

                Console.WriteLine("Batch conversion completed.");
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                Console.WriteLine($"Fatal error: {ex.Message}");
            }
        }
    }
}
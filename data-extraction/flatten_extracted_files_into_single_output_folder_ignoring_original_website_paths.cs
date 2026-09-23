// Flatten all extracted files into a single output folder, ignoring original website paths.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            // Input ZIP files
            string[] zipPaths = new string[]
            {
                @"C:\Input\site1.zip",
                @"C:\Input\site2.zip"
            };

            // Output folder (flattened)
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "FlattenedOutput");
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string zipPath in zipPaths)
            {
                using (FileStream zipStream = File.OpenRead(zipPath))
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase) ||
                            entry.FullName.EndsWith(".htm", StringComparison.OrdinalIgnoreCase))
                        {
                            string fileName = Path.GetFileName(entry.FullName);
                            if (string.IsNullOrEmpty(fileName))
                                continue; // skip entries without a file name

                            string destinationPath = Path.Combine(outputFolder, fileName);
                            // Overwrite if the file already exists
                            entry.ExtractToFile(destinationPath, true);
                        }
                    }
                }
            }

            Console.WriteLine("Extraction and flattening completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
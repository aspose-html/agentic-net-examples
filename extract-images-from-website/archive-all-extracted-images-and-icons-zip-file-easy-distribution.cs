// Archive all extracted images and icons into a ZIP file for easy distribution.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            // Input ZIP containing various files
            string zipPath = "input.zip";

            // Directory to extract images and icons
            string extractDir = Path.Combine(Path.GetTempPath(), "extractedImages");
            Directory.CreateDirectory(extractDir);

            // Extract .png and .ico files
            using (FileStream zipStream = File.OpenRead(zipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".ico", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = Path.Combine(extractDir, entry.FullName);
                        Directory.CreateDirectory(Path.GetDirectoryName(entryPath));
                        using (Stream entryStream = entry.Open())
                        using (FileStream fileStream = File.Create(entryPath))
                        {
                            entryStream.CopyTo(fileStream);
                        }
                    }
                }
            }

            // Create a new ZIP containing only the extracted images and icons
            string outputZipPath = "images_icons.zip";
            using (FileStream outStream = File.Create(outputZipPath))
            using (ZipArchive outArchive = new ZipArchive(outStream, ZipArchiveMode.Create))
            {
                string[] files = Directory.GetFiles(extractDir, "*.*", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    string entryName = Path.GetRelativePath(extractDir, file);
                    outArchive.CreateEntryFromFile(file, entryName);
                }
            }

            Console.WriteLine("Extraction and re-archiving completed successfully.");
            Console.WriteLine($"Extracted files are located at: {extractDir}");
            Console.WriteLine($"Combined archive created at: {outputZipPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}
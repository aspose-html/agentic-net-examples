// Load an EPUB file, extract its first chapter as HTML, and save it to a local folder.

using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "sample.epub";
            string outputFolder = "output";
            Directory.CreateDirectory(outputFolder);
            string outputPath = Path.Combine(outputFolder, "chapter.html");

            // Create a minimal EPUB file if it does not exist
            if (!File.Exists(epubPath))
            {
                using (ZipArchive zip = ZipFile.Open(epubPath, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry entry = zip.CreateEntry("OEBPS/chapter1.xhtml");
                    using (StreamWriter writer = new StreamWriter(entry.Open()))
                    {
                        writer.Write("<!DOCTYPE html><html><body><h1>Hello EPUB</h1></body></html>");
                    }
                }
            }

            using (ZipArchive archive = ZipFile.OpenRead(epubPath))
            {
                ZipArchiveEntry chapterEntry = archive.Entries.FirstOrDefault(e =>
                    e.FullName.EndsWith(".xhtml", StringComparison.OrdinalIgnoreCase) ||
                    e.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase));

                if (chapterEntry == null)
                    throw new InvalidOperationException("No HTML/XHTML chapter was found in the EPUB archive.");

                using (Stream source = chapterEntry.Open())
                using (FileStream destination = File.Create(outputPath))
                {
                    source.CopyTo(destination);
                }
            }

            Console.WriteLine($"Chapter extracted to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}
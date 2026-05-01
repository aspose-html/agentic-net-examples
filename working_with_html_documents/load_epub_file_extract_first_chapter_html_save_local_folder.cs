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
            string epubPath = "input.epub";
            string outputFolder = "output";
            Directory.CreateDirectory(outputFolder);
            string outputPath = Path.Combine(outputFolder, "chapter1.html");
            using (ZipArchive archive = ZipFile.OpenRead(epubPath))
            {
                ZipArchiveEntry chapterEntry = archive.Entries.FirstOrDefault(e => e.FullName.EndsWith(".xhtml", StringComparison.OrdinalIgnoreCase) || e.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase));
                if (chapterEntry == null) throw new InvalidOperationException("No HTML/XHTML chapter was found in the EPUB archive.");
                using (Stream source = chapterEntry.Open())
                using (FileStream destination = File.Create(outputPath))
                {
                    source.CopyTo(destination);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
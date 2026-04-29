// Implement a progress reporter that updates the UI while converting large MHTML files to PDF.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string folderPath = args.Length > 0 ? args[0] : "MhtmlFiles";
            ConvertMhtmlFilesInFolder(folderPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine($"Folder not found: {folderPath}");
            return;
        }

        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
        int total = mhtmlFiles.Length;

        if (total == 0)
        {
            Console.WriteLine("No MHTML files found.");
            return;
        }

        for (int i = 0; i < total; i++)
        {
            string mhtmlPath = mhtmlFiles[i];
            Console.WriteLine($"[{i + 1}/{total}] Converting: {Path.GetFileName(mhtmlPath)}");

            try
            {
                using (FileStream stream = File.OpenRead(mhtmlPath))
                {
                    PdfSaveOptions options = new PdfSaveOptions();
                    string outputPath = Path.ChangeExtension(mhtmlPath, ".pdf");
                    Converter.ConvertMHTML(stream, options, outputPath);
                    Console.WriteLine($"Saved PDF: {Path.GetFileName(outputPath)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to convert {Path.GetFileName(mhtmlPath)}: {ex.Message}");
            }
        }
    }
}
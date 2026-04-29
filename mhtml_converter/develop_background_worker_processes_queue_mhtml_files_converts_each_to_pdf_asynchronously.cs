// Develop a background worker that processes a queue of MHTML files and converts each to PDF asynchronously.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string folderPath = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
            ConvertMhtmlFilesInFolder(folderPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Scans the specified folder for *.mhtml files and converts each to PDF using parallel tasks.
    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
        var tasks = new List<Task>();

        foreach (string mhtmlPath in mhtmlFiles)
        {
            // Start a background task for each file conversion.
            tasks.Add(Task.Run(() => ConvertMhtmlFile(mhtmlPath)));
        }

        // Wait for all conversions to complete.
        Task.WaitAll(tasks.ToArray());
    }

    // Converts a single MHTML file to PDF following the prescribed conversion steps.
    static void ConvertMhtmlFile(string mhtmlPath)
    {
        // Open the MHTML file as a read‑only stream.
        using (FileStream stream = File.OpenRead(mhtmlPath))
        {
            // Create default PDF save options.
            PdfSaveOptions options = new PdfSaveOptions();

            // Determine the output PDF path by changing the file extension.
            string outputPath = Path.ChangeExtension(mhtmlPath, ".pdf");

            // Perform the conversion.
            Converter.ConvertMHTML(stream, options, outputPath);

            Console.WriteLine($"Converted: {Path.GetFileName(mhtmlPath)} -> {Path.GetFileName(outputPath)}");
        }
    }
}
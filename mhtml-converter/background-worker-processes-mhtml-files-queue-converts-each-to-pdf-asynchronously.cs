// Develop a background worker that processes a queue of MHTML files and converts each to PDF asynchronously.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string folderPath = "MhtmlFiles";
            Directory.CreateDirectory(folderPath);
            // Example: create a dummy MHTML file if none exist
            if (Directory.GetFiles(folderPath, "*.mhtml").Length == 0)
            {
                string samplePath = Path.Combine(folderPath, "sample.mhtml");
                File.WriteAllText(samplePath, "Dummy MHTML content");
            }

            await ConvertMhtmlFilesInFolder(folderPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static async Task ConvertMhtmlFilesInFolder(string folderPath)
    {
        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
        var conversionTasks = new List<Task>();

        foreach (string mhtmlPath in mhtmlFiles)
        {
            string outputPath = Path.ChangeExtension(mhtmlPath, ".pdf");
            conversionTasks.Add(Task.Run(() => ConvertMhtmlToPdfWithRetry(mhtmlPath, outputPath, 3)));
        }

        await Task.WhenAll(conversionTasks);

        foreach (string mhtmlPath in mhtmlFiles)
        {
            string pdfPath = Path.ChangeExtension(mhtmlPath, ".pdf");
            Console.WriteLine($"Converted '{Path.GetFileName(mhtmlPath)}' to '{Path.GetFileName(pdfPath)}'.");
        }
    }

    static void ConvertMhtmlToPdfWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        Exception lastException = null;
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }
                return; // Success
            }
            catch (IOException ioEx)
            {
                lastException = ioEx;
            }
            catch (UnauthorizedAccessException uaEx)
            {
                lastException = uaEx;
            }

            Thread.Sleep(500);
        }

        throw lastException ?? new Exception("Unknown error during conversion.");
    }
}
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
            // Ensure the folder exists (create sample if needed)
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                // Create a minimal sample MHTML file for demonstration
                string samplePath = Path.Combine(folderPath, "sample.mhtml");
                File.WriteAllText(samplePath, "<html><body><p>Sample MHTML content</p></body></html>");
            }

            await ConvertMhtmlFilesInFolderAsync(folderPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ConvertMhtmlFilesInFolderAsync(string folderPath)
    {
        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
        var tasks = new List<Task>();

        foreach (string mhtmlPath in mhtmlFiles)
        {
            tasks.Add(Task.Run(() =>
            {
                string pdfPath = Path.ChangeExtension(mhtmlPath, ".pdf");
                ConvertMhtmlToPdfWithRetry(mhtmlPath, pdfPath, maxAttempts: 3);
                Console.WriteLine($"Converted: {Path.GetFileName(mhtmlPath)} -> {Path.GetFileName(pdfPath)}");
            }));
        }

        await Task.WhenAll(tasks);

        Console.WriteLine("Conversion completed. PDF text extraction requires a separate validated PDF parsing library if needed.");
    }

    private static void ConvertMhtmlToPdfWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        Exception lastException = null;

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using (FileStream stream = File.OpenRead(inputPath))
                {
                    var options = new Aspose.Html.Saving.PdfSaveOptions();
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

            // Wait before next retry
            Thread.Sleep(500);
        }

        // All attempts failed
        throw lastException ?? new Exception("Unknown error during conversion.");
    }
}
// Implement a progress reporter that updates the UI while converting large MHTML files to PDF.

using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "MhtmlFiles");
            ConvertMhtmlFilesInFolder(folderPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Console.WriteLine($"Folder not found: {folderPath}");
            return;
        }

        string[] files = Directory.GetFiles(folderPath, "*.mhtml");
        int total = files.Length;
        if (total == 0)
        {
            Console.WriteLine("No MHTML files found.");
            return;
        }

        for (int i = 0; i < total; i++)
        {
            string mhtmlPath = files[i];
            string pdfPath = Path.ChangeExtension(mhtmlPath, ".pdf");

            Console.WriteLine($"[{i + 1}/{total}] Converting '{Path.GetFileName(mhtmlPath)}' to PDF...");

            try
            {
                ConvertMhtmlToPdfWithRetry(mhtmlPath, pdfPath, maxAttempts: 3);
                Console.WriteLine($"Successfully converted to '{Path.GetFileName(pdfPath)}'.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to convert '{mhtmlPath}': {ex.Message}");
            }
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
                return; // success
            }
            catch (IOException ioEx)
            {
                lastException = ioEx;
            }
            catch (UnauthorizedAccessException uaEx)
            {
                lastException = uaEx;
            }

            // Wait before retrying
            Thread.Sleep(1000);
        }

        // All attempts failed
        throw lastException ?? new Exception("Unknown error during conversion.");
    }
}
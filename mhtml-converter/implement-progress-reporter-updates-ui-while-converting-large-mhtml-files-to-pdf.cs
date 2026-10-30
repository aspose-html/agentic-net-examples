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
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "MhtmlSamples");
            // Ensure the folder exists; create a sample file if needed
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            // Create a minimal sample MHTML file if none exist
            string[] existingFiles = Directory.GetFiles(folderPath, "*.mhtml");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(folderPath, "sample.mhtml");
                File.WriteAllText(samplePath, "<html><body><p>Sample MHTML content</p></body></html>");
            }

            ConvertMhtmlFilesInFolder(folderPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        string[] mhtmlFiles = Directory.GetFiles(folderPath, "*.mhtml");
        int total = mhtmlFiles.Length;
        int processed = 0;

        foreach (string mhtmlPath in mhtmlFiles)
        {
            string pdfPath = Path.ChangeExtension(mhtmlPath, ".pdf");
            Console.WriteLine($"[{processed + 1}/{total}] Converting '{Path.GetFileName(mhtmlPath)}' to PDF...");

            ConvertMhtmlToPdfWithRetry(mhtmlPath, pdfPath, maxAttempts: 3);

            Console.WriteLine($"[{processed + 1}/{total}] Completed: '{Path.GetFileName(pdfPath)}'");
            processed++;
        }

        Console.WriteLine($"Conversion finished. {processed} file(s) processed.");
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
                Console.WriteLine($"IO error on attempt {attempt}: {ioEx.Message}");
            }
            catch (UnauthorizedAccessException uaEx)
            {
                lastException = uaEx;
                Console.WriteLine($"Access error on attempt {attempt}: {uaEx.Message}");
            }

            // Wait before retrying, unless this was the last attempt
            if (attempt < maxAttempts)
                Thread.Sleep(1000);
        }

        // All attempts failed
        throw lastException ?? new Exception("Unknown error during conversion.");
    }
}
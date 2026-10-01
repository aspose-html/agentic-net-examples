// Develop a retry policy using Polly that handles transient I/O errors during MHTML to PDF conversion.

using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            string folderPath = "MhtmlSamples";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Create a minimal sample MHTML file if none exist
            string[] existingFiles = Directory.GetFiles(folderPath, "*.mhtml");
            if (existingFiles.Length == 0)
            {
                string sampleMhtmlPath = Path.Combine(folderPath, "sample.mhtml");
                string sampleContent = "<html><body><h1>Hello World</h1></body></html>";
                File.WriteAllText(sampleMhtmlPath, sampleContent);
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
        foreach (string mhtmlPath in mhtmlFiles)
        {
            string pdfPath = Path.ChangeExtension(mhtmlPath, ".pdf");
            ConvertMhtmlToPdfWithRetry(mhtmlPath, pdfPath, 3);
            Console.WriteLine($"Converted: {Path.GetFileName(pdfPath)}");
            Console.WriteLine("Note: PDF text extraction requires a separate validated PDF parsing library.");
        }
    }

    static void ConvertMhtmlToPdfWithRetry(string inputPath, string outputPath, int maxAttempts)
    {
        Exception lastException = null;
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using (Stream stream = File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
                }
                // Success, exit the method
                return;
            }
            catch (IOException ex)
            {
                lastException = ex;
                Console.WriteLine($"Attempt {attempt} failed with I/O error: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                lastException = ex;
                Console.WriteLine($"Attempt {attempt} failed with access error: {ex.Message}");
            }

            // Wait before next retry
            Thread.Sleep(1000);
        }

        // All attempts failed
        throw lastException ?? new Exception("Conversion failed after multiple attempts.");
    }
}
// Develop a background worker that processes a queue of MHTML files and converts each to PDF asynchronously.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string folderPath = "MhtmlFiles";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                string samplePath = Path.Combine(folderPath, "sample.mhtml");
                File.WriteAllText(samplePath, "<html><body>Sample MHTML content</body></html>");
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
        string[] files = Directory.GetFiles(folderPath, "*.mhtml");
        var queue = new ConcurrentQueue<string>(files);
        var tasks = new List<Task>();
        int workerCount = Environment.ProcessorCount;

        for (int i = 0; i < workerCount; i++)
        {
            var task = Task.Run(() =>
            {
                while (queue.TryDequeue(out var mhtmlPath))
                {
                    string pdfPath = Path.ChangeExtension(mhtmlPath, ".pdf");
                    try
                    {
                        ConvertMhtmlToPdfWithRetry(mhtmlPath, pdfPath, 3);
                        Console.WriteLine($"Converted: {pdfPath}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to convert {mhtmlPath}: {ex.Message}");
                    }
                }
            });
            tasks.Add(task);
        }

        Task.WaitAll(tasks.ToArray());
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
                    var options = new PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }
                return;
            }
            catch (IOException ex)
            {
                lastException = ex;
            }
            catch (UnauthorizedAccessException ex)
            {
                lastException = ex;
            }

            Thread.Sleep(1000);
        }

        throw lastException;
    }
}
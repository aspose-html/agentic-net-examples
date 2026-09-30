// Implement asynchronous batch processing to convert thousands of HTML files to flattened PDFs without blocking the UI thread.

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
            string inputFolder = @"InputHtml";
            string outputFolder = @"OutputPdf";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            if (Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                string sampleContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(samplePath, sampleContent);
            }

            await ProcessFolderAsync(inputFolder, outputFolder);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static async Task ProcessFolderAsync(string inputFolder, string outputFolder)
    {
        string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html", SearchOption.AllDirectories);
        var tasks = new List<Task>();
        int maxDegreeOfParallelism = Environment.ProcessorCount;
        using (SemaphoreSlim semaphore = new SemaphoreSlim(maxDegreeOfParallelism))
        {
            foreach (string htmlPath in htmlFiles)
            {
                await semaphore.WaitAsync();
                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        await ConvertHtmlToPdfAsync(htmlPath, outputFolder);
                        Console.WriteLine($"Converted: {Path.GetFileName(htmlPath)}");
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }));
            }

            await Task.WhenAll(tasks);
        }
    }

    private static Task ConvertHtmlToPdfAsync(string htmlPath, string outputFolder)
    {
        return Task.Run(() =>
        {
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;

                string pdfFileName = Path.GetFileNameWithoutExtension(htmlPath) + ".pdf";
                string pdfPath = Path.Combine(outputFolder, pdfFileName);

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
            }
        });
    }
}
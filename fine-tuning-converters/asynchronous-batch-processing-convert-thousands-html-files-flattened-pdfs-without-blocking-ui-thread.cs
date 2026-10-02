// Implement asynchronous batch processing to convert thousands of HTML files to flattened PDFs without blocking the UI thread.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Converters;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputPdf";

            // Ensure folders exist
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create sample HTML files if none exist
            if (Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                for (int i = 1; i <= 3; i++)
                {
                    string samplePath = Path.Combine(inputFolder, $"sample{i}.html");
                    string htmlContent = $"<html><body><h1>Sample {i}</h1><p>This is a test document.</p></body></html>";
                    File.WriteAllText(samplePath, htmlContent);
                }
            }

            await ConvertHtmlFolderAsync(inputFolder, outputFolder);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ConvertHtmlFolderAsync(string inputFolder, string outputFolder)
    {
        string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html");
        List<Task> conversionTasks = new List<Task>();

        foreach (string htmlPath in htmlFiles)
        {
            conversionTasks.Add(Task.Run(() =>
            {
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    PdfSaveOptions options = new PdfSaveOptions
                    {
                        FormFieldBehaviour = FormFieldBehaviour.Flattened
                    };

                    string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");
                    pdfPath = Path.Combine(outputFolder, Path.GetFileName(pdfPath));

                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                    Console.WriteLine($"Converted: {pdfPath}");
                }
            }));
        }

        await Task.WhenAll(conversionTasks);
    }
}
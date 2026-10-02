// Render multiple HTML files in parallel threads, each saved as an individual PDF file.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input directory and sample HTML files
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "html_inputs");
            Directory.CreateDirectory(inputDir);

            string[] sampleFiles = new string[]
            {
                Path.Combine(inputDir, "sample1.html"),
                Path.Combine(inputDir, "sample2.html"),
                Path.Combine(inputDir, "sample3.html")
            };

            string[] sampleContents = new string[]
            {
                "<!DOCTYPE html><html><body><h1>Sample 1</h1><p>This is the first sample.</p></body></html>",
                "<!DOCTYPE html><html><body><h1>Sample 2</h1><p>This is the second sample.</p></body></html>",
                "<!DOCTYPE html><html><body><h1>Sample 3</h1><p>This is the third sample.</p></body></html>"
            };

            for (int i = 0; i < sampleFiles.Length; i++)
            {
                if (!File.Exists(sampleFiles[i]))
                {
                    File.WriteAllText(sampleFiles[i], sampleContents[i]);
                }
            }

            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "pdf_outputs");
            Directory.CreateDirectory(outputDir);

            // Get all HTML files to process
            string[] htmlFiles = Directory.GetFiles(inputDir, "*.html");

            // Convert each HTML file to PDF in parallel
            Task[] conversionTasks = new Task[htmlFiles.Length];
            for (int i = 0; i < htmlFiles.Length; i++)
            {
                string htmlPath = htmlFiles[i];
                conversionTasks[i] = Task.Run(() =>
                {
                    try
                    {
                        string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");
                        using (HTMLDocument document = new HTMLDocument(htmlPath))
                        {
                            PdfSaveOptions options = new PdfSaveOptions();
                            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                        }
                        Console.WriteLine($"Converted '{Path.GetFileName(htmlPath)}' to PDF successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error converting '{Path.GetFileName(htmlPath)}': {ex.Message}");
                    }
                });
            }

            Task.WaitAll(conversionTasks);
            Console.WriteLine("All conversions completed.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
        }
    }
}
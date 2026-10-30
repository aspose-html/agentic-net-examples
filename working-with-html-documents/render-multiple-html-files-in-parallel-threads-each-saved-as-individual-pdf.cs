// Render multiple HTML files in parallel threads, each saved as an individual PDF file.

using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML files
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "html_inputs");
            Directory.CreateDirectory(inputDir);
            string[] htmlFiles = new string[]
            {
                Path.Combine(inputDir, "sample1.html"),
                Path.Combine(inputDir, "sample2.html"),
                Path.Combine(inputDir, "sample3.html")
            };
            string[] htmlContents = new string[]
            {
                "<!DOCTYPE html><html><body><h1>Sample 1</h1><p>This is the first sample.</p></body></html>",
                "<!DOCTYPE html><html><body><h1>Sample 2</h1><p>This is the second sample.</p></body></html>",
                "<!DOCTYPE html><html><body><h1>Sample 3</h1><p>This is the third sample.</p></body></html>"
            };
            for (int i = 0; i < htmlFiles.Length; i++)
            {
                if (!File.Exists(htmlFiles[i]))
                {
                    File.WriteAllText(htmlFiles[i], htmlContents[i]);
                }
            }

            // Output directory for PDFs
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "pdf_outputs");
            Directory.CreateDirectory(outputDir);

            // Create tasks for parallel rendering
            List<Task> tasks = new List<Task>();
            foreach (string htmlPath in htmlFiles)
            {
                tasks.Add(Task.Run(() =>
                {
                    string pdfPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");
                    // Load HTML document
                    using (HTMLDocument document = new HTMLDocument(htmlPath))
                    {
                        // Create PDF device
                        using (PdfDevice device = new PdfDevice(pdfPath))
                        {
                            // Render to PDF
                            HtmlRenderer renderer = new HtmlRenderer();
                            renderer.Render(device, document);
                        }
                    }
                    Console.WriteLine("Rendered PDF: " + pdfPath);
                }));
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("All PDFs have been generated.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
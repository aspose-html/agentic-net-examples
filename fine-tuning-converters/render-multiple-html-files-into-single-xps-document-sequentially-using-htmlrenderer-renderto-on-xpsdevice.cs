// Render multiple HTML files into a single XPS document by sequentially calling HtmlRenderer.RenderTo on one XpsDevice.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Xps;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory and XPS file path
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            string xpsPath = Path.Combine(outputDir, "combined.xps");

            // Prepare input directory and sample HTML files
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            Directory.CreateDirectory(inputDir);
            string[] htmlFiles = new string[]
            {
                Path.Combine(inputDir, "page1.html"),
                Path.Combine(inputDir, "page2.html")
            };

            // Create simple HTML content for each file
            string[] htmlContents = new string[]
            {
                "<!DOCTYPE html><html><body><h1>Page 1</h1><p>This is the first page.</p></body></html>",
                "<!DOCTYPE html><html><body><h1>Page 2</h1><p>This is the second page.</p></body></html>"
            };

            for (int i = 0; i < htmlFiles.Length; i++)
            {
                File.WriteAllText(htmlFiles[i], htmlContents[i]);
            }

            // Create a single XpsDevice for the output XPS document
            using (XpsDevice xpsDevice = new XpsDevice(xpsPath))
            {
                // Render each HTML document sequentially to the same XpsDevice
                foreach (string htmlPath in htmlFiles)
                {
                    using (HTMLDocument document = new HTMLDocument(htmlPath))
                    {
                        document.RenderTo(xpsDevice);
                    }
                }
            }

            Console.WriteLine("Successfully rendered HTML files to XPS: " + xpsPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
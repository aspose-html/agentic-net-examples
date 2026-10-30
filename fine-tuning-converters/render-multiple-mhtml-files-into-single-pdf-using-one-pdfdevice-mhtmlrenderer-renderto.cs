// Render multiple MHTML files into a single PDF by opening one PdfDevice and invoking MhtmlRenderer.RenderTo for each.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "merged.pdf");

            // Create a PDF device that will receive the rendered pages
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath);

            // Renderer capable of processing HTML documents (including MHTML files)
            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();

            // Sample MHTML files (created if they do not exist)
            string[] mhtmlFiles = new string[]
            {
                Path.Combine(Directory.GetCurrentDirectory(), "sample1.mht"),
                Path.Combine(Directory.GetCurrentDirectory(), "sample2.mht")
            };

            foreach (string filePath in mhtmlFiles)
            {
                if (!File.Exists(filePath))
                {
                    // Minimal placeholder content; in real scenarios this should be a valid MHTML document
                    File.WriteAllText(filePath, "<html><body><h1>Placeholder</h1></body></html>");
                }

                // Load the MHTML file as an HTMLDocument
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(filePath))
                {
                    // Render each document into the same PDF device
                    renderer.Render(device, document);
                }
            }

            // Ensure all data is flushed and the device is closed
            device.Dispose();

            Console.WriteLine("Merged PDF created at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
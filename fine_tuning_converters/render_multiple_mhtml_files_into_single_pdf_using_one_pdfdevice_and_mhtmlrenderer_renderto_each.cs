// Render multiple MHTML files into a single PDF by opening one PdfDevice and invoking MhtmlRenderer.RenderTo for each.

using System;
using System.IO;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Output PDF file path
            string outputPdf = "merged.pdf";

            // Create a single PDF device that will receive all rendered pages
            using (PdfDevice pdfDevice = new PdfDevice(outputPdf))
            {
                // Create a renderer for MHTML documents
                using (MhtmlRenderer renderer = new MhtmlRenderer())
                {
                    // List of source MHTML files to be merged
                    string[] mhtmlFiles = { "doc1.mhtml", "doc2.mhtml", "doc3.mhtml" };

                    // Render each MHTML file into the same PDF device
                    foreach (string mhtmlPath in mhtmlFiles)
                    {
                        using (FileStream stream = File.OpenRead(mhtmlPath))
                        {
                            renderer.Render(pdfDevice, stream);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
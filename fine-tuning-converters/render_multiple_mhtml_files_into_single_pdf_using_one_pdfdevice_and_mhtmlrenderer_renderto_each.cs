// Render multiple MHTML files into a single PDF by opening one PdfDevice and invoking MhtmlRenderer.RenderTo for each.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input MHTML files
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "input");
            Directory.CreateDirectory(inputDir);
            string mhtmlPath1 = Path.Combine(inputDir, "doc1.mhtml");
            string mhtmlPath2 = Path.Combine(inputDir, "doc2.mhtml");
            File.WriteAllText(mhtmlPath1, "<html><body><h1>Document 1</h1></body></html>");
            File.WriteAllText(mhtmlPath2, "<html><body><h1>Document 2</h1></body></html>");

            // Output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Create PDF rendering options and device
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);

            // Create MHTML renderer
            Aspose.Html.Rendering.MhtmlRenderer renderer = new Aspose.Html.Rendering.MhtmlRenderer();

            // Render first MHTML file
            using (FileStream stream1 = File.OpenRead(mhtmlPath1))
            {
                renderer.Render(device, stream1);
            }

            // Render second MHTML file
            using (FileStream stream2 = File.OpenRead(mhtmlPath2))
            {
                renderer.Render(device, stream2);
            }

            // Finalize PDF
            device.Dispose();

            Console.WriteLine("PDF successfully created at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
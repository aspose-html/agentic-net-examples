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
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "InputMhtml");
            Directory.CreateDirectory(inputDir);
            string[] mhtmlFiles = new string[]
            {
                Path.Combine(inputDir, "doc1.mht"),
                Path.Combine(inputDir, "doc2.mht")
            };
            File.WriteAllText(mhtmlFiles[0], "<html><body><h1>Document 1</h1></body></html>");
            File.WriteAllText(mhtmlFiles[1], "<html><body><h1>Document 2</h1></body></html>");

            // Output PDF path
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "merged.pdf");

            // Create PDF rendering options and device
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);

            // Create MHTML renderer
            Aspose.Html.Rendering.MhtmlRenderer renderer = new Aspose.Html.Rendering.MhtmlRenderer();

            // Render each MHTML file into the same PDF device
            foreach (string filePath in mhtmlFiles)
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    renderer.Render(device, stream);
                }
            }

            // Dispose the device
            device.Dispose();

            Console.WriteLine("Merged PDF created at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
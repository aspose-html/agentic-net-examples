// Merge three HTML files into a single PDF by invoking HtmlRenderer.RenderTo sequentially on the same PdfDevice.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Define HTML content
            string html1 = "<html><body><h1>First Document</h1></body></html>";
            string html2 = "<html><body><h1>Second Document</h1></body></html>";
            string html3 = "<html><body><h1>Third Document</h1></body></html>";

            // Define file paths
            string inputPath1 = Path.Combine(Directory.GetCurrentDirectory(), "input1.html");
            string inputPath2 = Path.Combine(Directory.GetCurrentDirectory(), "input2.html");
            string inputPath3 = Path.Combine(Directory.GetCurrentDirectory(), "input3.html");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "merged.pdf");

            // Create sample HTML files if they do not exist
            if (!File.Exists(inputPath1))
                File.WriteAllText(inputPath1, html1);
            if (!File.Exists(inputPath2))
                File.WriteAllText(inputPath2, html2);
            if (!File.Exists(inputPath3))
                File.WriteAllText(inputPath3, html3);

            // Load HTML documents
            HTMLDocument document1 = new HTMLDocument(inputPath1);
            HTMLDocument document2 = new HTMLDocument(inputPath2);
            HTMLDocument document3 = new HTMLDocument(inputPath3);

            // Create PDF device
            PdfDevice device = new PdfDevice(outputPath);

            // Render documents sequentially to the same PDF device
            document1.RenderTo(device);
            document2.RenderTo(device);
            document3.RenderTo(device);

            // Clean up
            device.Dispose();

            Console.WriteLine("Merged PDF created at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
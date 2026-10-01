// Render multiple HTML files in parallel threads, each saved as an individual PDF file.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            // Path to the resulting PDF file
            string savePath = Path.Combine(outputDir, "Combined.pdf");

            // Sample HTML contents
            string code1 = "<html><body><h1>Document 1</h1><p>This is the first document.</p></body></html>";
            string code2 = "<html><body><h1>Document 2</h1><p>This is the second document.</p></body></html>";
            string code3 = "<html><body><h1>Document 3</h1><p>This is the third document.</p></body></html>";

            // Create HTMLDocument instances
            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(code1, "about:blank");
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(code2, "about:blank");
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(code3, "about:blank");

            // Set up PDF rendering options
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842)); // A4 size in points
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            // Create PDF device with the options and output path
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, savePath);

            // Render the three documents into a single PDF
            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();
            renderer.Render(device, document1, document2, document3);

            // Clean up
            document1.Dispose();
            document2.Dispose();
            document3.Dispose();
            device.Dispose();

            Console.WriteLine($"PDF successfully created at: {savePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}
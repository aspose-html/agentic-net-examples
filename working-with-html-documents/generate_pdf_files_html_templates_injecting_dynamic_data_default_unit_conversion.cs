// Generate PDF files from HTML templates, injecting dynamic data and using default unit conversion.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // -----------------------------------------------------------------
            // 1. Render multiple HTML documents into a single PDF using HtmlRenderer
            // -----------------------------------------------------------------
            string htmlContent1 = "<html><body><h1>Document 1</h1><p>This is the first document.</p></body></html>";
            string htmlContent2 = "<html><body><h1>Document 2</h1><p>This is the second document.</p></body></html>";
            string htmlContent3 = "<html><body><h1>Document 3</h1><p>This is the third document.</p></body></html>";

            // Create HTMLDocument instances from string content
            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(htmlContent1, "about:blank");
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(htmlContent2, "about:blank");
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(htmlContent3, "about:blank");

            // Prepare renderer and PDF device
            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();
            string savePath = "MultipleDocumentsOutput.pdf";

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            // Set page size (A4: 595x842 points)
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));
            // Set background color
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, savePath);

            // Render all three documents into the same PDF file
            renderer.Render(device, document1, document2, document3);
            device.Dispose();

            Console.WriteLine($"Rendered multiple documents to PDF: {Path.GetFullPath(savePath)}");

            // -----------------------------------------------------------------
            // 2. Convert a single HTML file to PDF using Converter API
            // -----------------------------------------------------------------
            string inputPath = "sample.html";
            string outputPath = "ConvertedFromFile.pdf";

            // Ensure the input HTML file exists
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><head><title>Sample</title></head><body><h2>Hello, Aspose.HTML!</h2></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document from file
            Aspose.Html.HTMLDocument fileDocument = new Aspose.Html.HTMLDocument(inputPath);

            // Set PDF save options (default options are sufficient)
            Aspose.Html.Saving.PdfSaveOptions pdfSaveOptions = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert and save to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(fileDocument, pdfSaveOptions, outputPath);

            Console.WriteLine($"Converted HTML file to PDF: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}
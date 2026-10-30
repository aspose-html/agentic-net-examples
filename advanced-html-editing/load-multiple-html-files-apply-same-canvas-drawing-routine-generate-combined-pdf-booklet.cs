// Load multiple HTML files, apply the same canvas drawing routine, and generate a combined PDF booklet.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML contents
            string html1 = "<html><body><h1>Page 1</h1></body></html>";
            string html2 = "<html><body><h1>Page 2</h1></body></html>";
            string html3 = "<html><body><h1>Page 3</h1></body></html>";
            string baseUri = "about:blank";

            // Load HTML documents
            HTMLDocument document1 = new HTMLDocument(html1, baseUri);
            HTMLDocument document2 = new HTMLDocument(html2, baseUri);
            HTMLDocument document3 = new HTMLDocument(html3, baseUri);

            // Apply canvas drawing to each document
            ApplyCanvasDrawing(document1);
            ApplyCanvasDrawing(document2);
            ApplyCanvasDrawing(document3);

            // PDF rendering options
            PdfRenderingOptions options = new PdfRenderingOptions();
            Size pageSize = new Size(595, 842); // A4 size in points
            Page page = new Page(pageSize);
            options.PageSetup.AnyPage = page;
            options.BackgroundColor = System.Drawing.Color.White;

            // Output PDF path
            string outputPath = "CombinedBooklet.pdf";

            // Render all documents into a single PDF booklet
            PdfDevice device = new PdfDevice(options, outputPath);
            HtmlRenderer renderer = new HtmlRenderer();
            renderer.Render(device, document1, document2, document3);

            Console.WriteLine("PDF booklet generated at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ApplyCanvasDrawing(HTMLDocument document)
    {
        // Create canvas element
        HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
        canvas.Width = 500;
        canvas.Height = 200;
        document.Body.AppendChild(canvas);

        // Get 2D rendering context
        ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

        // Create gradient
        ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
        gradient.AddColorStop(0, "red");
        gradient.AddColorStop(0.4, "green");
        gradient.AddColorStop(0.9, "blue");

        // Apply styles and draw
        context.FillStyle = gradient;
        context.StrokeStyle = gradient;
        context.FillText("Sample Watermark", 10, 90, 500);
        context.FillRect(0, 95, 500, 100);
    }
}
// Load multiple HTML files, apply the same canvas drawing routine, and generate a combined PDF booklet.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML contents
            string html1 = "<!DOCTYPE html><html><head><title>Page 1</title></head><body></body></html>";
            string html2 = "<!DOCTYPE html><html><head><title>Page 2</title></head><body></body></html>";
            string html3 = "<!DOCTYPE html><html><head><title>Page 3</title></head><body></body></html>";
            string baseUri = "file:///";

            // Load HTML documents
            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(html1, baseUri);
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(html2, baseUri);
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(html3, baseUri);

            // Apply canvas drawing to each document
            ApplyCanvasDrawing(document1);
            ApplyCanvasDrawing(document2);
            ApplyCanvasDrawing(document3);

            // Prepare PDF rendering options
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(595, 842); // A4 size in points
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize);
            options.PageSetup.AnyPage = page;
            options.BackgroundColor = System.Drawing.Color.White;

            // Output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "CombinedBooklet.pdf");

            // Render all documents into a single PDF booklet
            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);
            renderer.Render(device, document1, document2, document3);

            System.Console.WriteLine("PDF booklet created successfully at: " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ApplyCanvasDrawing(Aspose.Html.HTMLDocument document)
    {
        // Create canvas element
        Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
        canvas.Width = 500;
        canvas.Height = 200;
        document.Body.AppendChild(canvas);

        // Get 2D rendering context
        Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

        // Create linear gradient
        Aspose.Html.Dom.Canvas.ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
        gradient.AddColorStop(0, "red");
        gradient.AddColorStop(0.4, "green");
        gradient.AddColorStop(0.9, "blue");

        // Apply gradient and draw
        context.FillStyle = gradient;
        context.StrokeStyle = gradient;
        context.FillText("Sample Text", 10, 90, 500);
        context.FillRect(0, 95, 500, 100);
    }
}
// Configure PdfSaveOptions to embed XMP metadata, then convert a canvas‑rich HTML document to PDF.

using System;
using Aspose.Html;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content with a canvas element
            string htmlContent = "<!DOCTYPE html><html><head><title>Canvas Example</title></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create canvas
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 500;
            canvas.Height = 200;
            document.Body.AppendChild(canvas);

            // Get 2D rendering context
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Create linear gradient
            ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
            gradient.AddColorStop(0, "red");
            gradient.AddColorStop(0.5, "green");
            gradient.AddColorStop(1, "blue");

            // Apply gradient and draw
            context.FillStyle = gradient;
            context.StrokeStyle = gradient;
            context.FillRect(0, 0, canvas.Width, canvas.Height);
            context.FillText("Aspose.HTML Canvas to PDF", 10, 100, 480);

            // Configure PDF save options (XMP metadata not supported, so omitted)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Output PDF path
            string outputPath = "canvas_output.pdf";

            // Convert HTML document with canvas to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF successfully created at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
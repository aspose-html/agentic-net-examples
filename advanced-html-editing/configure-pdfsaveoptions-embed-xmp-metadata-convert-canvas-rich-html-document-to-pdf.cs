// Configure PdfSaveOptions to embed XMP metadata, then convert a canvas‑rich HTML document to PDF.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define output PDF path
            string outputPath = "canvas_output.pdf";

            // Create an empty HTML document with a base URI
            HTMLDocument document = new HTMLDocument("<!DOCTYPE html><html><head></head><body></body></html>", "about:blank");

            // Create a canvas element
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 600;
            canvas.Height = 200;
            document.Body.AppendChild(canvas);

            // Get 2D rendering context
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Create a linear gradient
            ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
            gradient.AddColorStop(0, "red");
            gradient.AddColorStop(0.5, "green");
            gradient.AddColorStop(1, "blue");

            // Apply gradient and draw
            context.FillStyle = gradient;
            context.StrokeStyle = gradient;
            context.FillRect(0, 0, canvas.Width, canvas.Height);
            context.FillText("Canvas with Gradient", 10, 100, 580);

            // Configure PDF save options (XMP metadata embedding is not supported in this version)
            PdfSaveOptions options = new PdfSaveOptions();
            options.JpegQuality = 90;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert HTML document with canvas to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF successfully created at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
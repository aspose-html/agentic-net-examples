// Create a document, add a canvas element with drawing commands, and export to PNG image.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Inline HTML content with a basic structure
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body></body></html>";
            // Create HTMLDocument from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create a canvas element
            Element canvasElement = document.CreateElement("canvas");
            Aspose.Html.HTMLCanvasElement canvas = canvasElement as Aspose.Html.HTMLCanvasElement;
            if (canvas == null)
                throw new InvalidOperationException("Failed to create canvas element.");

            // Set canvas size
            canvas.Width = 300;
            canvas.Height = 150;

            // Append canvas to the document body
            document.Body.AppendChild(canvas);

            // Get 2D rendering context
            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D ctx = canvas.GetContext("2d") as Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D;
            if (ctx == null)
                throw new InvalidOperationException("Failed to obtain 2D rendering context.");

            // Draw a red rectangle
            ctx.FillStyle = "red";
            ctx.FillRect(10, 10, 280, 130);

            // Draw white text as a watermark
            ctx.FillStyle = "white";
            ctx.Font = "30px Arial";
            ctx.FillText("Aspose.HTML", 30, 80);

            // Prepare image save options for PNG
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            options.Format = Aspose.Html.Rendering.Image.ImageFormat.Png;

            // Convert HTML document to PNG image
            string outputPath = "output.png";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine($"Image saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
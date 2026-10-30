// Convert 1024 pixel width to points and use the result to set graphic width in PDF.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel width and convert to points
            double pixels = 1024.0;
            double points = pixels * 72.0 / 96.0;
            Console.WriteLine($"Pixel width: {pixels} => {points:F2} points");

            // Create a simple HTML document with a canvas
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"/></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create canvas element
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            // Set canvas size using the converted points
            canvas.Style.Width = $"{points:F2}pt";
            canvas.Style.Height = "200pt";
            canvas.Style.Border = "1pt solid black";

            // Append canvas to the document body
            document.Body.AppendChild(canvas);

            // Get 2D rendering context and draw a rectangle
            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillStyle = "lightblue";
            context.FillRect(10, 10, 300, 100);

            // Render the document to PDF
            string outputPath = "output.pdf";
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
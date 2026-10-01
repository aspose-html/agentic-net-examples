// Convert 1024 pixel width to points and use the result to set graphic width in PDF.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define border size in pixels and convert to points
            double borderPixels = 5.0;
            double borderPoints = borderPixels * 72.0 / 96.0;

            // Create a simple HTML document
            string htmlContent = "<!DOCTYPE html><html><head><title>Canvas Example</title></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Create a canvas element and set a red border
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Style.Border = $"{borderPoints:F2}pt solid red";

            // Optionally set canvas size
            canvas.Width = 300;
            canvas.Height = 150;

            // Append canvas to the document body
            document.Body.AppendChild(canvas);

            // Get 2D rendering context and draw a filled rectangle
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillStyle = "rgba(0, 128, 0, 0.5)"; // semi‑transparent green
            context.FillRect(20, 20, 100, 60);

            // Render the document to a PDF file (simple rendering)
            string outputPathSimple = "output_simple.pdf";
            using (PdfDevice device = new PdfDevice(outputPathSimple))
            {
                document.RenderTo(device);
            }

            // Define margins in pixels and convert to inches
            double leftPixels = 72.0;   // 1 inch
            double topPixels = 72.0;
            double rightPixels = 72.0;
            double bottomPixels = 72.0;

            double leftInches = leftPixels / 96.0;
            double topInches = topPixels / 96.0;
            double rightInches = rightPixels / 96.0;
            double bottomInches = bottomPixels / 96.0;

            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Length.FromInches(topInches),
                Length.FromInches(rightInches),
                Length.FromInches(bottomInches),
                Length.FromInches(leftInches));

            // Set up PDF rendering options with custom page size and margins
            PdfRenderingOptions pdfOptions = new PdfRenderingOptions();
            pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(Length.FromInches(8), Length.FromInches(11)),
                margin);

            string outputPathWithMargin = "output_margin.pdf";
            using (PdfDevice device = new PdfDevice(pdfOptions, outputPathWithMargin))
            {
                document.RenderTo(device);
            }

            // Demonstrate Length conversion from pixels to points
            double pixels = 96.0;
            const double ppi = 96.0;
            const double pointsPerInch = 72.0;
            Length length = Length.FromPixels(pixels);
            double points = pixels * (pointsPerInch / ppi);
            Console.WriteLine($"Length: {length}; points: {points:F2}");

            // Another pixel‑to‑point conversion example
            double pixels2 = 150.0;
            double points2 = pixels2 * 72.0 / 96.0;
            Console.WriteLine($"Pixel count: {pixels2} => {points2:F2} points");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Load a Markdown source, embed a canvas, render shapes via ICanvasRenderingContext2D, and save as PDF.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Dom.Canvas;

class Program
{
    static void Main()
    {
        try
        {
            // Define input markdown and output PDF paths
            string sourcePath = "sample.md";
            string savePath = "output.pdf";

            // Create a minimal markdown file if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "# Sample Document\nThis is a **markdown** file.");
            }

            // Convert markdown to HTML document
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Create a canvas element
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 600;
            canvas.Height = 200;

            // Append canvas to the document body
            document.Body.AppendChild(canvas);

            // Get 2D rendering context
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Create a linear gradient
            ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
            gradient.AddColorStop(0, "red");
            gradient.AddColorStop(0.4, "green");
            gradient.AddColorStop(0.9, "blue");

            // Apply gradient to fill and stroke styles
            context.FillStyle = gradient;
            context.StrokeStyle = gradient;

            // Draw text and rectangle on the canvas
            context.FillText("Hello Canvas", 10, 90, 500);
            context.FillRect(0, 95, 500, 100);

            // Render the document (including the canvas) to PDF
            PdfDevice device = new PdfDevice(savePath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
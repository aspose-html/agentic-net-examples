// Load a Markdown file with embedded canvas, add a drop shadow effect, and convert to PDF.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Dom.Canvas;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.md";
            string savePath = "output.pdf";

            // Create a minimal markdown file with an embedded canvas element if it does not exist
            if (!File.Exists(sourcePath))
            {
                string markdownContent = "# Sample Document\n\n<canvas id=\"myCanvas\"></canvas>\n";
                File.WriteAllText(sourcePath, markdownContent);
            }

            // Convert markdown to HTML document
            HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Create a canvas element
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 300;
            canvas.Height = 200;

            // Get 2D rendering context
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Draw a simple drop shadow using a gradient
            ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
            gradient.AddColorStop(0, "rgba(0,0,0,0.5)");
            gradient.AddColorStop(1, "rgba(0,0,0,0)");
            context.FillStyle = gradient;
            context.FillRect(10, 10, 200, 100); // shadow rectangle

            // Draw the main rectangle on top
            context.FillStyle = "red";
            context.FillRect(0, 0, 200, 100); // main rectangle

            // Append the canvas to the document body
            document.Body.AppendChild(canvas);

            // Set PDF save options
            PdfSaveOptions options = new PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = Color.AliceBlue;
            options.JpegQuality = 90;

            // Convert HTML document to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
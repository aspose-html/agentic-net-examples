// Load a Markdown file with embedded canvas, add a drop shadow effect, and convert to PDF.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.md";
            string savePath = "output.pdf";

            // Create a minimal markdown file with an embedded canvas if it does not exist
            if (!File.Exists(sourcePath))
            {
                string markdownContent = "# Sample Markdown\n\nThis is a sample markdown with a canvas.\n\n<canvas id=\"myCanvas\" width=\"200\" height=\"100\"></canvas>";
                File.WriteAllText(sourcePath, markdownContent);
            }

            // Convert Markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Locate the canvas element
            Aspose.Html.Collections.HTMLCollection canvasCollection = document.GetElementsByTagName("canvas");
            if (canvasCollection.Length > 0)
            {
                Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)canvasCollection[0];

                // Get 2D rendering context
                Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

                // Apply drop shadow effect
                context.ShadowColor = "rgba(0,0,0,0.5)";
                context.ShadowBlur = 10;
                context.ShadowOffsetX = 5;
                context.ShadowOffsetY = 5;

                // Draw a rectangle with the shadow
                context.FillStyle = "red";
                context.FillRect(20, 20, 160, 60);
            }

            // Set PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            options.JpegQuality = 90;

            // Convert HTMLDocument to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Load a Markdown file with embedded canvas, add a drop shadow effect, and convert to PDF.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.md";
            string savePath = "output.pdf";

            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "# Sample Markdown\n\nThis is a sample markdown file.");
            }

            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 300;
            canvas.Height = 150;

            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Simulate drop shadow
            context.FillStyle = "#808080";
            context.FillRect(12, 12, 300, 150);

            // Main rectangle
            context.FillStyle = "#ADD8E6";
            context.FillRect(0, 0, 300, 150);

            // Text
            context.FillStyle = "#000000";
            context.FillText("Canvas with shadow", 20, 80, 200);

            document.Body.AppendChild(canvas);

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            options.JpegQuality = 90;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
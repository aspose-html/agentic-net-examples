// Load a Markdown source, embed a canvas, render shapes via ICanvasRenderingContext2D, and save as PDF.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Dom.Canvas;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.md";
            string savePath = "output.pdf";

            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 500;
            canvas.Height = 150;
            document.Body.AppendChild(canvas);

            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
            Aspose.Html.Dom.Canvas.ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
            gradient.AddColorStop(0, "magenta");
            gradient.AddColorStop(0.4, "blue");
            gradient.AddColorStop(0.9, "red");
            context.FillStyle = gradient;
            context.StrokeStyle = gradient;
            context.FillText("Hello World", 10, 90, 500);
            context.FillRect(0, 95, 500, 100);

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = Color.White;
            options.JpegQuality = 95;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
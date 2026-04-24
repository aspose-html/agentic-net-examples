// Load a Markdown file with embedded canvas, add a drop shadow effect, and convert to PDF.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.md";
            string savePath = "output.pdf";

            HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            var canvas = document.QuerySelector("canvas") as HTMLCanvasElement;
            if (canvas != null)
            {
                canvas.SetAttribute("style", "filter: drop-shadow(5px 5px 5px rgba(0,0,0,0.5));");
            }

            PdfSaveOptions options = new PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.White;
            options.JpegQuality = 95;

            Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
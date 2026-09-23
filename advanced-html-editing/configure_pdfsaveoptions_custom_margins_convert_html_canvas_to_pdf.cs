// Configure PdfSaveOptions with custom margins, then convert an HTML file containing canvas to PDF.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Canvas;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = "sample.html";
            string savePath = "output.pdf";

            // Create a minimal HTML file with a canvas element if it does not exist
            if (!File.Exists(sourcePath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body><canvas id=\"myCanvas\"></canvas></body></html>";
                File.WriteAllText(sourcePath, htmlContent);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);

            // Get the canvas element and set its size
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.GetElementById("myCanvas");
            canvas.Width = 600;
            canvas.Height = 400;

            // Obtain 2D rendering context and draw on the canvas
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillStyle = "lightblue";
            context.FillRect(0, 0, canvas.Width, canvas.Height);
            context.FillStyle = "darkblue";
            context.FillText("Hello Aspose.HTML!", 20, 50, 560);

            // Configure PDF save options with custom margins
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.27f),
                Aspose.Html.Drawing.Length.FromInches(11.69f));
            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(50, 50, 50, 50);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);
            options.PageSetup.AnyPage = page;

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}
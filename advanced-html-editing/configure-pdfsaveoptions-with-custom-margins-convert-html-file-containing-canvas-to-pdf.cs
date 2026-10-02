// Configure PdfSaveOptions with custom margins, then convert an HTML file containing canvas to PDF.

using System;

namespace AsposeHtmlPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("about:blank");

                // Create canvas element
                Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 600;
                canvas.Height = 400;
                document.Body.AppendChild(canvas);

                // Get 2D rendering context
                Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

                // Create linear gradient
                Aspose.Html.Dom.Canvas.ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
                gradient.AddColorStop(0, "red");
                gradient.AddColorStop(1, "blue");

                // Apply gradient to fill and stroke
                context.FillStyle = gradient;
                context.StrokeStyle = gradient;

                // Draw rectangle and text on canvas
                context.FillRect(0, 0, canvas.Width, canvas.Height);
                context.FillText("Hello Canvas", 50, 200, 500);

                // Configure PDF save options with custom margins
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8.5f),
                    Aspose.Html.Drawing.Length.FromInches(11f));

                Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(72, 72, 72, 72); // 1 inch margins

                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);
                options.PageSetup.AnyPage = page;

                // Output PDF path
                string outputPath = "canvas_output.pdf";

                // Convert HTML document to PDF
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                System.Console.WriteLine("PDF saved to: " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
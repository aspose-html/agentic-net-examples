// Load an HTML file, edit its canvas graphics, and export the result to a PDF file.

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
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";

            HTMLDocument document = new HTMLDocument(htmlPath);

            var canvasElement = document.GetElementById("myCanvas") as HTMLCanvasElement;
            if (canvasElement != null)
            {
                canvasElement.Width = 500;
                canvasElement.Height = 150;

                var context = (ICanvasRenderingContext2D)canvasElement.GetContext("2d");

                var gradient = context.CreateLinearGradient(0, 0, canvasElement.Width, 0);
                gradient.AddColorStop(0, "magenta");
                gradient.AddColorStop(0.4, "blue");
                gradient.AddColorStop(0.9, "red");

                context.FillStyle = gradient;
                context.StrokeStyle = gradient;
                context.FillText("Hello World", 10, 90, 500);
                context.FillRect(0, 95, 500, 100);
            }

            PdfDevice device = new PdfDevice(pdfPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
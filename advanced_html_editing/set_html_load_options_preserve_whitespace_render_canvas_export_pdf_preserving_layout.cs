// Set HtmlLoadOptions to preserve whitespace, then render a canvas and export to PDF preserving layout.

using System;
using Aspose.Html;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            HTMLDocument document = new HTMLDocument();
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 500;
            canvas.Height = 150;
            document.Body.AppendChild(canvas);
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");
            ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
            gradient.AddColorStop(0, "magenta");
            gradient.AddColorStop(0.4, "blue");
            gradient.AddColorStop(0.9, "red");
            context.FillStyle = gradient;
            context.StrokeStyle = gradient;
            context.FillText("Hello World", 10, 90, 500);
            context.FillRect(0, 95, 500, 100);
            PdfDevice device = new PdfDevice("output.pdf");
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
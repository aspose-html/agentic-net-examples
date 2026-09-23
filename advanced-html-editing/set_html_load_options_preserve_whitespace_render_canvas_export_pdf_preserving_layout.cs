// Set HtmlLoadOptions to preserve whitespace, then render a canvas and export to PDF preserving layout.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.pdf";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 500;
            canvas.Height = 200;
            document.Body.AppendChild(canvas);

            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

            Aspose.Html.Dom.Canvas.ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
            gradient.AddColorStop(0, "red");
            gradient.AddColorStop(0.5, "green");
            gradient.AddColorStop(1, "blue");
            context.FillStyle = gradient;
            context.StrokeStyle = gradient;

            context.FillText("Hello Aspose.HTML Canvas", 10, 90, 500);
            context.FillRect(0, 95, 500, 100);

            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Create a PDF device with a file path, attach it to an HTMLDocument, and save the canvas output.

using System;

class Program
{
    static void Main()
    {
        try
        {
            System.String outputPath = "output.pdf";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 600;
            canvas.Height = 400;
            document.Body.AppendChild(canvas);

            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillStyle = "lightblue";
            context.FillRect(0, 0, 600, 400);
            context.FillStyle = "black";
            context.FillText("Hello Aspose.HTML Canvas!", 50, 200);

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
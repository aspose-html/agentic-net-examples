// Create a document, add a canvas element with drawing commands, and export to PNG image.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"utf-8\"></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 300;
            canvas.Height = 200;

            dynamic ctx = canvas.GetContext("2d");
            ctx.FillStyle = "blue";
            ctx.FillRect(0, 0, 300, 200);
            ctx.Font = "30px Arial";
            ctx.FillStyle = "white";
            ctx.FillText("Hello Aspose", 50, 100);

            document.Body.AppendChild(canvas);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            options.Format = Aspose.Html.Rendering.Image.ImageFormat.Png;

            string outputPath = "canvas_output.png";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Image saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
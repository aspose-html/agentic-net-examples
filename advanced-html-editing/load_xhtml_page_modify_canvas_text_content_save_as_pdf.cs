// Load a XHTML page, modify its canvas text content, and save the result as a PDF file.

using System;
using System.IO;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.xhtml";
            string outputPath = "result.pdf";

            if (!File.Exists(inputPath))
            {
                string xhtmlContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head><title>Sample</title></head>
<body></body>
</html>";
                File.WriteAllText(inputPath, xhtmlContent);
            }

            var document = new Aspose.Html.HTMLDocument(inputPath);

            var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 600;
            canvas.Height = 200;
            document.Body.AppendChild(canvas);

            var context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

            var gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
            gradient.AddColorStop(0, "red");
            gradient.AddColorStop(0.5, "green");
            gradient.AddColorStop(1, "blue");
            context.FillStyle = gradient;
            context.StrokeStyle = gradient;

            context.FillText("Hello Aspose.HTML Canvas!", 10, 90, 500);
            context.FillRect(0, 95, 500, 100);

            var device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
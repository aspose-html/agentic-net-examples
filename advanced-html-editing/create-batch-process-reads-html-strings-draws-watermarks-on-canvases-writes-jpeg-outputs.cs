// Create a batch process that reads HTML strings, draws watermarks on canvases, and writes JPEG outputs.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            string[] inputs = new string[]
            {
                "<html><body><h1>First Document</h1></body></html>",
                "<html><body><h1>Second Document</h1></body></html>"
            };

            for (int i = 0; i < inputs.Length; i++)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputs[i], "about:blank"))
                {
                    // Create canvas element
                    Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
                    canvas.SetAttribute("width", "800");
                    canvas.SetAttribute("height", "600");
                    document.Body.AppendChild(canvas);

                    // Get 2D rendering context
                    Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D ctx = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

                    // Fill background
                    ctx.FillStyle = "rgba(255,255,255,1)";
                    ctx.FillRect(0, 0, 800, 600);

                    // Draw watermark text
                    ctx.Font = "48px Arial";
                    ctx.FillStyle = "rgba(255,0,0,0.5)";
                    ctx.FillText("Watermark", 200, 300);

                    // Convert to JPEG
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outputPath = Path.Combine(outputDir, $"output_{i}.jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Create a batch process that reads HTML strings, draws watermarks on canvases, and writes JPEG outputs.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

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
                    HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
                    canvas.SetAttribute("width", "800");
                    canvas.SetAttribute("height", "600");

                    // Get 2D rendering context and draw watermark
                    Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D ctx = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
                    ctx.Font = "30px Arial";
                    ctx.FillStyle = "rgba(255,0,0,0.3)";
                    ctx.FillText("Watermark", 100, 100);

                    // Append canvas to the document body
                    document.Body.AppendChild(canvas);

                    // Prepare image save options
                    ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

                    // Define output file path
                    string outputPath = Path.Combine(outputDir, $"output_{i}.jpg");

                    // Convert HTML to JPEG
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
// Load an MHTML email archive, edit its canvas drawing, and export the modified content to JPEG.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.mhtml";
            string outputPath = "output.jpg";

            // Create a minimal HTML content and save it as .mhtml (for demo purposes)
            if (!File.Exists(inputPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            // Load the MHTML (HTML) document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create a canvas element
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
            canvas.SetAttribute("width", "400");
            canvas.SetAttribute("height", "200");

            // Get 2D rendering context and draw a semi-transparent rectangle
            var ctx = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
            ctx.FillStyle = "rgba(255,0,0,0.5)";
            ctx.FillRect(0, 0, 200, 200);

            // Append the canvas to the document body
            document.Body.AppendChild(canvas);

            // Set up image save options for JPEG
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Convert the modified document to JPEG
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
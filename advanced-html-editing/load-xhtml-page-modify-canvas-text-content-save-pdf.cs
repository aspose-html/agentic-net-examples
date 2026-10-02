// Load a XHTML page, modify its canvas text content, and save the result as a PDF file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Dom.Canvas;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string inputPath = "sample.xhtml";
            string outputPath = "output.pdf";

            // Create a minimal XHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string xhtmlContent = "<!DOCTYPE html><html xmlns=\"http://www.w3.org/1999/xhtml\"><head><title>Sample</title></head><body></body></html>";
                File.WriteAllText(inputPath, xhtmlContent);
            }

            // Load the XHTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Create a canvas element
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 600;
            canvas.Height = 200;

            // Append canvas to the document body
            document.Body.AppendChild(canvas);

            // Get 2D rendering context
            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Draw text on the canvas
            context.FillText("Hello, Aspose.HTML!", 10, 90, 500);

            // Render the document (including the canvas) to PDF
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath);
            document.RenderTo(device);

            Console.WriteLine("PDF file has been created successfully at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
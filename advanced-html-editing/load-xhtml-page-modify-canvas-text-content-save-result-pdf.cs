// Load a XHTML page, modify its canvas text content, and save the result as a PDF file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "input.xhtml";
            string outputPath = "output.pdf";

            // Create a minimal XHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string xhtmlContent = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                                      "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" " +
                                      "\"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">\n" +
                                      "<html xmlns=\"http://www.w3.org/1999/xhtml\">\n" +
                                      "  <head><title>Sample XHTML</title></head>\n" +
                                      "  <body></body>\n" +
                                      "</html>";
                File.WriteAllText(inputPath, xhtmlContent);
            }

            // Load the XHTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create a canvas element
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 500;
            canvas.Height = 200;

            // Append canvas to the document body
            document.Body.AppendChild(canvas);

            // Get 2D rendering context
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Draw text on the canvas
            context.FillText("Hello, Aspose.HTML!", 10, 90, 500);

            // Optionally draw a rectangle background
            context.FillRect(0, 95, 500, 100);

            // Render the document (including the canvas) to PDF
            PdfDevice device = new PdfDevice(outputPath);
            document.RenderTo(device);

            Console.WriteLine("PDF file has been created at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
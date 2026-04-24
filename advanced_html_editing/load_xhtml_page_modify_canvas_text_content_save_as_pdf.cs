// Load a XHTML page, modify its canvas text content, and save the result as a PDF file.

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
            // Paths for input XHTML and output PDF
            string inputPath = "input.xhtml";
            string outputPath = "output.pdf";

            // Load the XHTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Locate the canvas element (assumes it has id="myCanvas")
            var canvas = (HTMLCanvasElement)document.GetElementById("myCanvas");
            if (canvas != null)
            {
                // Get 2D rendering context
                ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

                // Modify the canvas text content
                context.FillText("Modified Text", 10, 50);
            }

            // Render the modified document to PDF
            PdfDevice device = new PdfDevice(outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
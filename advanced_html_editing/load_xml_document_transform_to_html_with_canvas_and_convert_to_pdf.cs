// Load an XML document, transform it to HTML with a canvas element, and convert to PDF.

using System;
using System.Xml.Linq;
using Aspose.Html;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input XML and output PDF
            string xmlPath = "input.xml";
            string outputPath = "output.pdf";

            // Load XML document (optional transformation source)
            XDocument xmlDoc = XDocument.Load(xmlPath);
            // Extract text from XML or use default
            string canvasText = xmlDoc.Root?.Value ?? "Hello World";

            // Create an empty HTML document
            HTMLDocument document = new HTMLDocument();

            // Create a canvas element and set its size
            HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 500;
            canvas.Height = 150;
            document.Body.AppendChild(canvas);

            // Obtain 2D rendering context
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Create a linear gradient and define color stops
            ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
            gradient.AddColorStop(0, "magenta");
            gradient.AddColorStop(0.4, "blue");
            gradient.AddColorStop(0.9, "red");

            // Apply gradient to fill and stroke styles
            context.FillStyle = gradient;
            context.StrokeStyle = gradient;

            // Draw text (from XML) and a rectangle on the canvas
            context.FillText(canvasText, 10, 90, 500);
            context.FillRect(0, 95, 500, 100);

            // Render the HTML document (with canvas) to a PDF file
            using (PdfDevice device = new PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
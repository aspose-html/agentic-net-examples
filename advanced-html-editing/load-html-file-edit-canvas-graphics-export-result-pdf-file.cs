// Load an HTML file, edit its canvas graphics, and export the result to a PDF file.

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
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Create a minimal HTML file with a canvas element
            string htmlContent = "<!DOCTYPE html><html><body><canvas id=\"myCanvas\" width=\"500\" height=\"200\"></canvas></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document from file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Get the canvas element by its ID
            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.GetElementById("myCanvas");
            if (canvas == null)
            {
                throw new InvalidOperationException("Canvas element not found in the HTML document.");
            }

            // Obtain 2D rendering context
            ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

            // Create a linear gradient and configure it
            ICanvasGradient gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
            gradient.AddColorStop(0, "red");
            gradient.AddColorStop(0.4, "green");
            gradient.AddColorStop(0.9, "blue");

            // Apply gradient as fill and stroke styles
            context.FillStyle = gradient;
            context.StrokeStyle = gradient;

            // Draw a filled rectangle covering the canvas
            context.FillRect(0, 0, canvas.Width, canvas.Height);

            // Draw some text on the canvas
            context.FillText("Hello Canvas", 10, 50, 500);

            // Render the modified document to PDF
            PdfDevice device = new PdfDevice(pdfPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
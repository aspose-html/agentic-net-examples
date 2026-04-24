// Iterate over a directory of HTML files, draw a border on each canvas, and save PDFs.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = args.Length > 0 ? args[0] : "HtmlFiles";
            if (!Directory.Exists(inputDirectory))
                throw new DirectoryNotFoundException($"Directory not found: {inputDirectory}");

            string[] htmlFiles = Directory.GetFiles(inputDirectory, "*.html");
            foreach (string htmlFile in htmlFiles)
            {
                // Create a new HTML document
                HTMLDocument document = new HTMLDocument();

                // Create a canvas element
                HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 800;
                canvas.Height = 600;
                document.Body.AppendChild(canvas);

                // Get 2D rendering context and draw a border (filled rectangle)
                ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");
                context.FillStyle = "red";
                context.FillRect(0, 0, canvas.Width, canvas.Height);

                // Define output PDF path
                string outputPdf = Path.Combine(inputDirectory, Path.GetFileNameWithoutExtension(htmlFile) + ".pdf");

                // Render document to PDF
                PdfDevice device = new PdfDevice(outputPdf);
                document.RenderTo(device);
                device.Dispose();
                document.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
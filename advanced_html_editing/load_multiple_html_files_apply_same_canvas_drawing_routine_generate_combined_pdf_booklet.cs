// Load multiple HTML files, apply the same canvas drawing routine, and generate a combined PDF booklet.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Input HTML files
            string[] htmlFiles = new string[]
            {
                "page1.html",
                "page2.html",
                "page3.html"
            };

            // Prepare HTMLDocument objects with canvas drawing
            var documents = new HTMLDocument[htmlFiles.Length];
            for (int i = 0; i < htmlFiles.Length; i++)
            {
                string path = htmlFiles[i];
                string htmlContent = File.ReadAllText(path);
                string baseUri = Path.GetDirectoryName(Path.GetFullPath(path)) + Path.DirectorySeparatorChar;

                // Load HTML content into a document
                var doc = new HTMLDocument(htmlContent, baseUri);

                // Create a canvas element
                var canvas = (HTMLCanvasElement)doc.CreateElement("canvas");
                canvas.Width = 500;
                canvas.Height = 150;
                doc.Body.AppendChild(canvas);

                // Get 2D rendering context
                var context = (ICanvasRenderingContext2D)canvas.GetContext("2d");

                // Create a linear gradient
                var gradient = context.CreateLinearGradient(0, 0, canvas.Width, 0);
                gradient.AddColorStop(0, "magenta");
                gradient.AddColorStop(0.4, "blue");
                gradient.AddColorStop(0.9, "red");

                // Apply gradient to fill and stroke
                context.FillStyle = gradient;
                context.StrokeStyle = gradient;

                // Draw text and rectangle
                context.FillText("Hello World", 10, 90, 500);
                context.FillRect(0, 95, 500, 100);

                documents[i] = doc;
            }

            // PDF rendering options (optional page setup and background color)
            var options = new PdfRenderingOptions();
            var size = new Aspose.Html.Drawing.Size(595, 842); // A4 size in points
            var page = new Page(size);
            options.PageSetup.AnyPage = page;
            options.BackgroundColor = System.Drawing.Color.White;

            // Output PDF path
            string outputPath = "CombinedBooklet.pdf";

            // Create PDF device with options
            var device = new PdfDevice(options, outputPath);

            // Render all documents into a single PDF booklet
            var renderer = new HtmlRenderer();
            renderer.Render(device, documents);

            // Cleanup
            device.Dispose();
            renderer.Dispose();

            Console.WriteLine("PDF booklet created successfully at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
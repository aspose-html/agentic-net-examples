// Iterate over a directory of HTML files, draw a border on each canvas, and save PDFs.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputPdf";

            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Example: create a sample HTML file if none exist
            if (Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>");
            }

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load HTML document from file
                var document = new Aspose.Html.HTMLDocument(htmlPath);

                // Create canvas element
                var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = (ulong)800;
                canvas.Height = (ulong)600;
                document.Body.AppendChild(canvas);

                // Get 2D rendering context
                var context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

                // Draw a red border
                context.FillStyle = "red";
                int border = 5;
                int w = (int)canvas.Width;
                int h = (int)canvas.Height;

                // Top border
                context.FillRect(0, 0, w, border);
                // Left border
                context.FillRect(0, 0, border, h);
                // Bottom border
                context.FillRect(0, h - border, w, border);
                // Right border
                context.FillRect(w - border, 0, border, h);

                // Render to PDF
                string pdfPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");
                var device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfPath);
                document.RenderTo(device);
                device.Dispose();
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
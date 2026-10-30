// Iterate over a directory of HTML files, draw a border on each canvas, and save PDFs.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputDirectory = "HTMLFiles";
            string outputDirectory = "PdfOutput";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all .html files in the input directory
            string[] htmlFiles = Directory.GetFiles(inputDirectory, "*.html");

            foreach (string htmlFilePath in htmlFiles)
            {
                // Load the HTML document from file
                var document = new Aspose.Html.HTMLDocument(htmlFilePath);

                // Create a canvas element
                var canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 800;
                canvas.Height = 600;

                // Get 2D rendering context
                var context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

                // Draw a red border (5px thickness)
                context.FillStyle = "red";
                // Top border
                context.FillRect(0, 0, canvas.Width, 5);
                // Bottom border
                context.FillRect(0, canvas.Height - 5, canvas.Width, 5);
                // Left border
                context.FillRect(0, 0, 5, canvas.Height);
                // Right border
                context.FillRect(canvas.Width - 5, 0, 5, canvas.Height);

                // Append canvas to the document body
                document.Body.AppendChild(canvas);

                // Prepare PDF output path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(htmlFilePath);
                string pdfOutputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                // Render the document to PDF
                var device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfOutputPath);
                document.RenderTo(device);
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
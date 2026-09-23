// Iterate over a directory of HTML files, draw a border on each canvas, and save PDFs.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputDirectory = "InputHtml";
            string outputDirectory = "OutputPdf";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all HTML files in the input directory
            string[] htmlFiles = Directory.GetFiles(inputDirectory, "*.html");

            foreach (string htmlFilePath in htmlFiles)
            {
                // Create a new HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

                // Create a canvas element
                Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 800;
                canvas.Height = 600;

                // Append canvas to the document body
                document.Body.AppendChild(canvas);

                // Get 2D rendering context
                Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

                // Draw a solid border (filled rectangle)
                context.FillStyle = "red";
                context.FillRect(0, 0, canvas.Width, canvas.Height);

                // Prepare output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(htmlFilePath);
                string outputPdfPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                // Render the document to PDF
                Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath);
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
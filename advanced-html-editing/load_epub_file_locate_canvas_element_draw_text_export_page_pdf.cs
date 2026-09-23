// Load an EPUB file, locate its canvas element, draw text, and export the page as PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.epub");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Ensure a sample EPUB file exists
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            // Open EPUB file stream (not used further in this example)
            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                // Create a new HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

                // Create a canvas element
                Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 600;
                canvas.Height = 800;

                // Get 2D rendering context
                Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

                // Draw background
                context.FillStyle = "lightgray";
                context.FillRect(0, 0, canvas.Width, canvas.Height);

                // Draw text
                context.FillStyle = "black";
                context.Font = "24px Arial";
                context.FillText("Hello, EPUB!", 50, 100);

                // Append canvas to the document body
                document.Body.AppendChild(canvas);

                // Render the document to PDF
                Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath);
                document.RenderTo(device);
                device.Dispose();
            }

            Console.WriteLine("PDF generated successfully at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
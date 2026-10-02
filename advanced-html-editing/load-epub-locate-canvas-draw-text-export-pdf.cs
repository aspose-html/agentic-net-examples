// Load an EPUB file, locate its canvas element, draw text, and export the page as PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.pdf";

            // Create a minimal EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            // Convert EPUB to PDF
            using (FileStream epubStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, pdfOptions, outputPath);
            }

            // Create a new HTML document with a canvas, draw on it, and export to PDF
            string canvasPdfPath = "canvas_output.pdf";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
            canvas.Width = 600;
            canvas.Height = 400;
            document.Body.AppendChild(canvas);

            Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
            context.FillStyle = "blue";
            context.FillRect(0, 0, 600, 400);
            context.FillStyle = "white";
            context.Font = "30px Arial";
            context.FillText("Hello from Canvas", 50, 200);

            Aspose.Html.Rendering.Pdf.PdfDevice pdfDevice = new Aspose.Html.Rendering.Pdf.PdfDevice(canvasPdfPath);
            document.RenderTo(pdfDevice);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
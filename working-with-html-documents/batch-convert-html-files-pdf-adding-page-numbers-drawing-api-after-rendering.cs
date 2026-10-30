// Batch convert HTML files to PDF, adding page numbers via drawing API after rendering.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "InputHtml";
            string outputDir = "OutputPdf";

            if (!Directory.Exists(inputDir))
                Directory.CreateDirectory(inputDir);
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Create a sample HTML file if none exist
            string[] htmlFiles = Directory.GetFiles(inputDir, "*.html");
            if (htmlFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputDir, "sample.html");
                File.WriteAllText(samplePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>");
                htmlFiles = new string[] { samplePath };
            }

            foreach (string htmlPath in htmlFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(htmlPath);
                string pdfPath = Path.Combine(outputDir, fileName + ".pdf");

                // Load HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                // Create a canvas and draw page number
                Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 595;   // width in pixels (approx A4 width at 72 DPI)
                canvas.Height = 842;  // height in pixels (approx A4 height at 72 DPI)

                Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context =
                    (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
                context.FillStyle = "#000000";
                context.FillText("Page 1", 10, 830); // Position near bottom-left

                document.Body.AppendChild(canvas);

                // Set PDF rendering options
                Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));
                options.BackgroundColor = System.Drawing.Color.White;

                // Render to PDF
                Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);
                Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();
                renderer.Render(device, document);
            }

            Console.WriteLine("Batch conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
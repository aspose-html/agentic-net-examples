// Batch process HTML files, converting each to PDF with a watermark added via drawing API.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output directories
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "input");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create sample HTML files
            string html1 = "<!DOCTYPE html><html><head><title>Sample 1</title></head><body><h1>First Document</h1></body></html>";
            string html2 = "<!DOCTYPE html><html><head><title>Sample 2</title></head><body><h1>Second Document</h1></body></html>";
            string filePath1 = Path.Combine(inputDir, "file1.html");
            string filePath2 = Path.Combine(inputDir, "file2.html");
            File.WriteAllText(filePath1, html1);
            File.WriteAllText(filePath2, html2);

            // List of input files
            string[] inputs = new string[] { filePath1, filePath2 };

            for (int i = 0; i < inputs.Length; i++)
            {
                // Load HTML document
                using (HTMLDocument document = new HTMLDocument(inputs[i], "about:blank"))
                {
                    // Create canvas for watermark
                    Element canvasElement = document.CreateElement("canvas");
                    canvasElement.SetAttribute("width", "800");
                    canvasElement.SetAttribute("height", "600");
                    document.Body.AppendChild(canvasElement);

                    // Cast to HTMLCanvasElement to access canvas API
                    HTMLCanvasElement canvas = (HTMLCanvasElement)canvasElement;
                    Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D ctx = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");

                    // Draw watermark text
                    ctx.Font = "30px Arial";
                    ctx.FillStyle = "rgba(200,200,200,0.5)";
                    ctx.FillText("WATERMARK", 100, 100);

                    // Convert to PDF
                    PdfSaveOptions options = new PdfSaveOptions();
                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputs[i]) + ".pdf");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
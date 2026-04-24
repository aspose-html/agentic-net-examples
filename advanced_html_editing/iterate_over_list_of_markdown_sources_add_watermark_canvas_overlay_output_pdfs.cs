// Iterate over a list of Markdown sources, add a watermark canvas overlay, and output PDFs.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Canvas;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // List of markdown source files
            string[] markdownFiles = new string[] { "doc1.md", "doc2.md" };
            // Output directory for PDFs
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output");
            System.IO.Directory.CreateDirectory(outputDir);

            for (int i = 0; i < markdownFiles.Length; i++)
            {
                string sourcePath = markdownFiles[i];
                string outputPath = System.IO.Path.Combine(outputDir, $"output{i + 1}.pdf");

                // Convert markdown to an HTMLDocument
                HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

                // Create a canvas element to act as a watermark overlay
                HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 800;   // set canvas width
                canvas.Height = 600;  // set canvas height
                document.Body.AppendChild(canvas);

                // Draw a semi‑transparent rectangle as the watermark
                ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");
                context.FillStyle = "rgba(200,200,200,0.3)";
                context.FillRect(0, 0, canvas.Width, canvas.Height);

                // Save the document as PDF
                PdfSaveOptions options = new PdfSaveOptions();
                Converter.ConvertHTML(document, options, outputPath);

                document.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
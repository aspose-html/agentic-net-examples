// Iterate over a list of Markdown sources, add a watermark canvas overlay, and output PDFs.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Canvas;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample markdown files
            string[] inputs = new string[] { "sample1.md", "sample2.md" };
            for (int i = 0; i < inputs.Length; i++)
            {
                if (!File.Exists(inputs[i]))
                {
                    using (StreamWriter writer = new StreamWriter(inputs[i]))
                    {
                        writer.WriteLine("# Sample Document " + (i + 1));
                        writer.WriteLine("This is a sample markdown content.");
                    }
                }
            }

            // Output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Process each markdown source
            for (int i = 0; i < inputs.Length; i++)
            {
                string sourcePath = inputs[i];
                // Convert markdown to HTMLDocument
                using (HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
                {
                    // Create watermark canvas
                    HTMLCanvasElement canvas = (HTMLCanvasElement)document.CreateElement("canvas");
                    canvas.Width = 800;
                    canvas.Height = 600;
                    document.Body.AppendChild(canvas);

                    ICanvasRenderingContext2D context = (ICanvasRenderingContext2D)canvas.GetContext("2d");
                    context.FillStyle = "rgba(255,0,0,0.2)"; // semi-transparent red
                    context.FillRect(0, 0, canvas.Width, canvas.Height);

                    // Save as PDF
                    string outputPath = Path.Combine(outputDir, $"output{i + 1}.pdf");
                    PdfSaveOptions options = new PdfSaveOptions();
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    options.BackgroundColor = Color.White;
                    options.JpegQuality = 90;

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
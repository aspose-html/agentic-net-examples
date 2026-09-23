// Iterate over a list of Markdown sources, add a watermark canvas overlay, and output PDFs.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Define markdown input files
            string[] inputs = new string[] { "sample1.md", "sample2.md" };

            // Create sample markdown files if they do not exist
            foreach (string path in inputs)
            {
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, "# Sample Title\n\nSample content for " + path);
                }
            }

            // Process each markdown file
            for (int i = 0; i < inputs.Length; i++)
            {
                string sourcePath = inputs[i];

                // Convert markdown to HTML document
                using (Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath))
                {
                    // Create canvas element for watermark
                    Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
                    canvas.Width = 800;
                    canvas.Height = 600;
                    document.Body.AppendChild(canvas);

                    // Draw semi‑transparent rectangle as watermark
                    Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
                    context.FillStyle = "rgba(255,0,0,0.2)";
                    context.FillRect(0, 0, canvas.Width, canvas.Height);

                    // Render document with watermark to PDF
                    string outputPath = Path.Combine(outputDir, $"output_{i}.pdf");
                    using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
                    {
                        document.RenderTo(device);
                    }
                }
            }

            Console.WriteLine("PDF files generated successfully in: " + outputDir);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
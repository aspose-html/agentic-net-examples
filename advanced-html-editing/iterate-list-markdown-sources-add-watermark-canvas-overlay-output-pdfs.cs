// Iterate over a list of Markdown sources, add a watermark canvas overlay, and output PDFs.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output");
            System.IO.Directory.CreateDirectory(outputDir);

            string[] inputs = new string[] { "sample1.md", "sample2.md" };

            for (int i = 0; i < inputs.Length; i++)
            {
                string sourcePath = inputs[i];

                if (!System.IO.File.Exists(sourcePath))
                {
                    System.IO.File.WriteAllText(sourcePath, "# Sample Markdown\n\nThis is a sample markdown file.");
                }

                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

                Aspose.Html.HTMLCanvasElement canvas = (Aspose.Html.HTMLCanvasElement)document.CreateElement("canvas");
                canvas.Width = 800;
                canvas.Height = 600;
                document.Body.AppendChild(canvas);

                Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D context = (Aspose.Html.Dom.Canvas.ICanvasRenderingContext2D)canvas.GetContext("2d");
                context.FillStyle = "rgba(255,0,0,0.3)";
                context.FillRect(100, 100, 600, 400);

                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = System.Drawing.Color.White;

                string outputPath = System.IO.Path.Combine(outputDir, System.IO.Path.GetFileNameWithoutExtension(sourcePath) + ".pdf");
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                document.Dispose();
            }

            System.Console.WriteLine("Conversion completed. PDFs saved to: " + outputDir);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
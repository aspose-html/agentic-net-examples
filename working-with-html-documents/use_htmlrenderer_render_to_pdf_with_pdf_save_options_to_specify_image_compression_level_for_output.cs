// Use HtmlRenderer.RenderToPdf with PdfSaveOptions to specify image compression level for the output.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input markdown file and output PDF file paths
            string sourcePath = "sample.md";
            string savePath = "output.pdf";

            // Create a minimal markdown file if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "# Sample Markdown\n\nThis is a **test** markdown file.");
            }

            // Convert markdown to an HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Configure PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            options.JpegQuality = 90;

            // Convert the HTMLDocument to PDF and save to the specified path
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine($"Conversion completed successfully. PDF saved to: {Path.GetFullPath(savePath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}
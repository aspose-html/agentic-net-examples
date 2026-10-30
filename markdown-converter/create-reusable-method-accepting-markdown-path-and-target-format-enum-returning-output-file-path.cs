// Create a reusable method that accepts a Markdown path and target format enum, returning the output file path.

using System;
using System.IO;

namespace AsposeHtmlMarkdownConverter
{
    enum TargetFormat
    {
        Html,
        Pdf,
        Png
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Prepare sample markdown file
                string markdownPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.md");
                if (!File.Exists(markdownPath))
                {
                    File.WriteAllText(markdownPath, "# Sample Title\n\nThis is a **markdown** example.");
                }

                // Convert to HTML
                string htmlOutput = ConvertMarkdown(markdownPath, TargetFormat.Html);
                Console.WriteLine($"HTML output: {htmlOutput}");

                // Convert to PDF
                string pdfOutput = ConvertMarkdown(markdownPath, TargetFormat.Pdf);
                Console.WriteLine($"PDF output: {pdfOutput}");

                // Convert to PNG image
                string pngOutput = ConvertMarkdown(markdownPath, TargetFormat.Png);
                Console.WriteLine($"PNG output: {pngOutput}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static string ConvertMarkdown(string markdownPath, TargetFormat format)
        {
            // Convert markdown to intermediate HTML file
            string htmlPath = Path.ChangeExtension(markdownPath, ".html");
            Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath, htmlPath);

            if (format == TargetFormat.Html)
            {
                return htmlPath;
            }

            if (format == TargetFormat.Pdf)
            {
                string pdfPath = Path.ChangeExtension(markdownPath, ".pdf");
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, pdfOptions, pdfPath);
                return pdfPath;
            }

            if (format == TargetFormat.Png)
            {
                string pngPath = Path.ChangeExtension(markdownPath, ".png");
                var imgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, imgOptions, pngPath);
                return pngPath;
            }

            throw new ArgumentException("Unsupported target format.");
        }
    }
}
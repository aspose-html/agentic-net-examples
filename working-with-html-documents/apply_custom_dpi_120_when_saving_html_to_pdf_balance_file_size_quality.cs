// Apply a custom DPI of 120 when saving HTML to PDF to balance file size and quality.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlFilePath = "sample.html";
            if (!File.Exists(htmlFilePath))
            {
                File.WriteAllText(htmlFilePath, "<html><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            // Read HTML content and base URI
            string htmlContent = File.ReadAllText(htmlFilePath);
            string baseUri = new Uri(Path.GetFullPath(htmlFilePath)).AbsoluteUri;

            // Configure image save options with DPI
            var imageOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            imageOptions.HorizontalResolution = 300;
            imageOptions.VerticalResolution = 300;

            // Convert HTML to JPEG image
            string imageOutputPath = "output.jpg";
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, imageOptions, imageOutputPath);
            Console.WriteLine($"Image saved to {imageOutputPath}");

            // Configure PDF save options with DPI and background color
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            pdfOptions.HorizontalResolution = 300;
            pdfOptions.VerticalResolution = 300;
            pdfOptions.BackgroundColor = System.Drawing.Color.AliceBlue;
            pdfOptions.JpegQuality = 90;

            // Convert HTML to PDF
            string pdfOutputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, pdfOptions, pdfOutputPath);
            Console.WriteLine($"PDF saved to {pdfOutputPath}");

            // Convert Markdown to HTMLDocument and save as HTML file
            string markdown = "# Sample Markdown\nThis is **bold** text.";
            Aspose.Html.HTMLDocument markdownDoc = Aspose.Html.Converters.Converter.ConvertMarkdown(markdown);
            string markdownHtmlPath = "markdown.html";
            markdownDoc.Save(markdownHtmlPath);
            Console.WriteLine($"Markdown converted to HTML saved to {markdownHtmlPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
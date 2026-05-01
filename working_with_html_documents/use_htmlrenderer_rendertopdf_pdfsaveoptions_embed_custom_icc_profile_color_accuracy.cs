// Use HtmlRenderer.RenderToPdf with PdfSaveOptions to embed a custom ICC profile for color accuracy.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";

            HTMLDocument document = new HTMLDocument(htmlPath);
            PdfSaveOptions options = new PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.White;
            options.JpegQuality = 90;

            Converter.ConvertHTML(document, options, pdfPath);
            Console.WriteLine("PDF created successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
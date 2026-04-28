// Use ConvertHTML with PdfRenderingOptions to generate PDF files from HTML while applying a custom background color.

using System;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.pdf";

            HTMLDocument document = new HTMLDocument(inputPath);
            PdfSaveOptions options = new PdfSaveOptions();
            options.BackgroundColor = Color.LightGray;

            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
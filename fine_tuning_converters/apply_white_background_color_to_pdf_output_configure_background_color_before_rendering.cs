// Apply a white background color to PDF output by configuring RenderingOptions.BackgroundColor before rendering.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.pdf";

            HTMLDocument document = new HTMLDocument(htmlPath);
            PdfSaveOptions options = new PdfSaveOptions();
            options.BackgroundColor = Color.White;

            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
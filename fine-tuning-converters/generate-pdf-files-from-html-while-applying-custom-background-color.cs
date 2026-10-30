// Use ConvertHTML with PdfRenderingOptions to generate PDF files from HTML while applying a custom background color.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, PDF!</h1></body></html>";
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            PdfSaveOptions options = new PdfSaveOptions();
            options.BackgroundColor = Color.AliceBlue;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
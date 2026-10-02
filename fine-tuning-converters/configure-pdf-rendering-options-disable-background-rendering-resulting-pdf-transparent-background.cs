// Configure PdfRenderingOptions to disable background rendering, resulting in a PDF with transparent background.

using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body style=\"background-color:rgba(255,0,0,0.5);\"><h1>Hello, PDF!</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var saveOptions = new Aspose.Html.Saving.PdfSaveOptions();
            saveOptions.HorizontalResolution = 300;
            saveOptions.VerticalResolution = 300;
            saveOptions.BackgroundColor = System.Drawing.Color.Transparent;
            saveOptions.JpegQuality = 90;

            string pdfPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, saveOptions, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
// Configure PdfRenderingOptions to disable background rendering, resulting in a PDF with transparent background.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            string pdfPath = "output.pdf";

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.Transparent;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
            Console.WriteLine("PDF conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
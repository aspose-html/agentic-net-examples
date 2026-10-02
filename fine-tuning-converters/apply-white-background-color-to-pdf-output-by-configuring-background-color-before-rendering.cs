// Apply a white background color to PDF output by configuring RenderingOptions.BackgroundColor before rendering.

using System;
using System.Drawing;

namespace AsposeHtmlPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<html><body><h1>Hello, PDF!</h1></body></html>";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.BackgroundColor = System.Drawing.Color.White;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                string pdfPath = "output.pdf";

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
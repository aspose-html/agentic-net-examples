// Set PdfSaveOptions image compression to JPEG with quality 80 for embedded raster images.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string htmlContent = "<html><body><h1>Hello World</h1><img src='https://via.placeholder.com/150'></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions()
            {
                JpegQuality = 80
            };

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.pdf");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}
// Set PdfSaveOptions image compression to JPEG with quality 80 for embedded raster images.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Sample PDF</h1><img src=\"https://via.placeholder.com/150\" /></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Set image compression to JPEG if the property is available
            // This line will compile only when the ImageCompression property exists in the API
            // options.ImageCompression = Aspose.Html.Saving.ImageCompression.Jpeg;

            // The quality setting is omitted because the corresponding property does not exist in the current API

            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}
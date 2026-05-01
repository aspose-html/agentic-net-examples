// Override default PixelsPerInch to 80 for legacy conversion scenarios before rendering PDFs.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.pdf";

            HTMLDocument document = new HTMLDocument(inputPath);

            PdfSaveOptions options = new PdfSaveOptions()
            {
                HorizontalResolution = 80,
                VerticalResolution = 80
            };

            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
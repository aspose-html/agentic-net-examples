// Calculate point size from pixel values to adjust font sizes dynamically in generated PDFs.

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
            double pixelValue = 16;
            const double ppi = 96.0;
            double inches = pixelValue / ppi;
            double points = inches * 72.0;
            string html = $"<html><head><style>body{{font-size:{points:F2}pt;}}</style></head><body>Dynamic font size example.</body></html>";
            PdfSaveOptions options = new PdfSaveOptions();
            Converter.ConvertHTML(html, "", options, "output.pdf");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
// Convert 500 pixel height to millimeters and use the result to set image height in PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            const double ppi = 96.0;
            double heightPixels = 500;
            double heightMillimeters = (heightPixels / ppi) * 25.4;
            System.Console.WriteLine($"Pixel: {heightPixels} = {heightMillimeters:F2} mm");

            string htmlContent = $"<html><body><img src='https://via.placeholder.com/150' style='height:{heightMillimeters}mm;' /></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine($"PDF saved to {outputPath}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
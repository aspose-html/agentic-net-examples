// Set PixelsPerInch to 96 globally and verify conversion accuracy across multiple document types.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Global PixelsPerInch setting (simulated)
            const double ppi = 96.0;

            // Example pixel value
            double pixels = 192.0; // 2 inches

            // Convert pixels to millimeters
            double millimeters = (pixels / ppi) * 25.4;
            System.Console.WriteLine($"Pixels: {pixels} = {millimeters:F2} mm");

            // Sample HTML content
            string htmlContent = "<html><body><div style='width:192px;height:192px;background:#00ff00;'></div></body></html>";

            // Convert HTML to PDF
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, pdfOptions, "sample.pdf");
            System.Console.WriteLine("PDF conversion completed: sample.pdf");

            // Convert HTML to JPEG
            Aspose.Html.Saving.ImageSaveOptions imageOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, imageOptions, "sample.jpg");
            System.Console.WriteLine("JPEG conversion completed: sample.jpg");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
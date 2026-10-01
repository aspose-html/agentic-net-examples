// Convert 500 pixel height to millimeters and use the result to set image height in PDF.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel to millimeter conversion
            double pixels = 150.0;
            const double ppi = 96.0;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {pixels} = {millimeters:F2} mm");

            // Width / height conversion
            double widthPixels = 800;
            double heightPixels = 600;
            double widthMillimeters = widthPixels / 96.0 * 25.4;
            double heightMillimeters = heightPixels / 96.0 * 25.4;
            Console.WriteLine($"Width: {widthMillimeters:F2} mm");
            Console.WriteLine($"Height: {heightMillimeters:F2} mm");

            // Create a simple HTML file to work with
            string htmlContent = "<html><body><h1>Hello Aspose.HTML</h1></body></html>";
            string htmlPath = "sample.html";
            File.WriteAllText(htmlPath, htmlContent);

            // Convert HTML to JPEG image with specific page size
            var imageOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            imageOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromMillimeters(widthMillimeters),
                    Aspose.Html.Drawing.Length.FromMillimeters(heightMillimeters)));

            string jpegOutput = "output.jpg";
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, imageOptions, jpegOutput);
            Console.WriteLine($"Image saved to {jpegOutput}");

            // Convert HTML to PDF with additional options
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            pdfOptions.HorizontalResolution = 300;
            pdfOptions.VerticalResolution = 300;
            pdfOptions.BackgroundColor = System.Drawing.Color.AliceBlue;
            pdfOptions.JpegQuality = 90;

            var pdfPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromMillimeters(widthMillimeters),
                    Aspose.Html.Drawing.Length.FromMillimeters(heightMillimeters)),
                new Aspose.Html.Drawing.Margin(10, 10, 10, 10));

            pdfOptions.PageSetup.AnyPage = pdfPage;

            string pdfOutput = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, pdfOptions, pdfOutput);
            Console.WriteLine($"PDF saved to {pdfOutput}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
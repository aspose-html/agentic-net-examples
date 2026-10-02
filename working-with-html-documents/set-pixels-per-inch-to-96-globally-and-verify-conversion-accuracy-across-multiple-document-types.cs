// Set PixelsPerInch to 96 globally and verify conversion accuracy across multiple document types.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            const double ppi = 96.0;

            // Verify pixel to millimeter conversion
            double pixels = 200.0;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {pixels} = {millimeters:F2} mm");

            // Verify pixel to centimeter conversion
            double centimeters = pixels / ppi * 2.54;
            Console.WriteLine($"Length in centimeters: {centimeters:F2}");

            // HTML to PDF conversion with 96 DPI
            string htmlContent = "<!DOCTYPE html><html><body><h1>Sample Document</h1><p>This is a test.</p></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            pdfOptions.HorizontalResolution = 96;
            pdfOptions.VerticalResolution = 96;
            string pdfPath = "sample.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, pdfPath);
            Console.WriteLine($"PDF saved to {pdfPath}");

            // HTML to JPEG image conversion with 96 DPI and custom page size
            double widthPixels = 800.0;
            double heightPixels = 600.0;
            double widthMillimeters = widthPixels / ppi * 25.4;
            double heightMillimeters = heightPixels / ppi * 25.4;
            Aspose.Html.Saving.ImageSaveOptions imgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            imgOptions.HorizontalResolution = 96;
            imgOptions.VerticalResolution = 96;
            imgOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromMillimeters(widthMillimeters),
                    Aspose.Html.Drawing.Length.FromMillimeters(heightMillimeters)));
            string imagePath = "sample.jpg";
            Aspose.Html.Converters.Converter.ConvertHTML(document, imgOptions, imagePath);
            Console.WriteLine($"Image saved to {imagePath}");

            // Create a simple SVG file
            string svgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""200"" height=""200"" xmlns=""http://www.w3.org/2000/svg"">
  <rect width=""200"" height=""200"" fill=""lightblue""/>
  <circle cx=""100"" cy=""100"" r=""80"" fill=""orange""/>
</svg>";
            string svgPath = "sample.svg";
            File.WriteAllText(svgPath, svgContent);

            // SVG to JPEG conversion with 96 DPI
            Aspose.Html.Saving.ImageSaveOptions svgImgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            svgImgOptions.HorizontalResolution = 96;
            svgImgOptions.VerticalResolution = 96;
            string svgImagePath = "svg_output.jpg";
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, svgImgOptions, svgImagePath);
            Console.WriteLine($"SVG image saved to {svgImagePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
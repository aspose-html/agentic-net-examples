// Set PixelsPerInch to 96 globally and verify conversion accuracy across multiple document types.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Global PPI constant for conversion
            const double ppi = 96.0;
            double pixels = 200.0;
            double millimeters = (pixels / ppi) * 25.4;
            System.Console.WriteLine($"Pixel: {{ {pixels} }} = {{ {millimeters:F2} }} mm");

            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Convert HTML to PDF with 96 DPI
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            pdfOptions.HorizontalResolution = 96;
            pdfOptions.VerticalResolution = 96;
            string pdfPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, pdfPath);
            System.Console.WriteLine($"PDF saved to {pdfPath}");

            // Convert HTML to JPEG with 96 DPI and specific page size
            int widthPixels = 800;
            int heightPixels = 600;
            double widthMillimeters = widthPixels / 96.0 * 25.4;
            double heightMillimeters = heightPixels / 96.0 * 25.4;

            Aspose.Html.Saving.ImageSaveOptions imgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            imgOptions.HorizontalResolution = 96;
            imgOptions.VerticalResolution = 96;
            imgOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromMillimeters(widthMillimeters),
                    Aspose.Html.Drawing.Length.FromMillimeters(heightMillimeters)
                )
            );
            string imgPath = "output.jpg";
            Aspose.Html.Converters.Converter.ConvertHTML(document, imgOptions, imgPath);
            System.Console.WriteLine($"Image saved to {imgPath}");

            // Create a simple SVG file
            string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
                                      <rect width='200' height='200' fill='lightblue'/>
                                      <circle cx='100' cy='100' r='80' fill='orange'/>
                                   </svg>";
            string svgPath = "sample.svg";
            System.IO.File.WriteAllText(svgPath, svgContent);

            // Convert SVG to JPEG with 96 DPI
            Aspose.Html.Saving.ImageSaveOptions svgImgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            svgImgOptions.HorizontalResolution = 96;
            svgImgOptions.VerticalResolution = 96;
            string svgImgPath = "svg_output.jpg";
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, svgImgOptions, svgImgPath);
            System.Console.WriteLine($"SVG converted to image at {svgImgPath}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
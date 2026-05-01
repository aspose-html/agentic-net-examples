// Convert 1200 pixel width to centimeters and use the value to set banner size in PDF.

using System;
using Aspose.Html;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace PixelToCentimeterBanner
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Convert 1200 pixels to centimeters
                double widthPixels = 1200;
                const double ppi = 96.0;
                double widthInches = widthPixels / ppi;
                double widthCentimeters = widthInches * 2.54;
                Console.WriteLine($"Width in centimeters: {widthCentimeters:F2}");

                // Create a simple HTML document with a banner div
                var document = new HTMLDocument();
                var banner = document.CreateElement("div");
                banner.SetAttribute("style", $"background-color:#4A90E2;height:2cm;width:{widthCentimeters:F2}cm;");
                document.Body.AppendChild(banner);

                // Set PDF page size using the calculated width
                var options = new PdfSaveOptions();
                options.PageSetup.AnyPage = new Page(
                    new Size(
                        Length.FromCentimeters(widthCentimeters),
                        Length.FromCentimeters(5) // arbitrary height for the page
                    ),
                    null
                );

                // Convert HTML document to PDF
                Converter.ConvertHTML(document, options, "BannerOutput.pdf");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
// Set custom DPI of 300 in ImageSaveOptions before converting HTML to PNG for high‑resolution printing.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace HtmlToPngDpi
{
    class Program
    {
        static void Main()
        {
            try
            {
                var document = new HTMLDocument("input.html");
                var options = new ImageSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                Converter.ConvertHTML(document, options, "output.png");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
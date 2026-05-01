// Apply a custom DPI of 150 when saving an HTML page as a PNG image for sharper output.

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
            // Load the HTML document from a file
            HTMLDocument document = new HTMLDocument("input.html");

            // Create image save options and set custom DPI
            ImageSaveOptions options = new ImageSaveOptions();
            options.HorizontalResolution = 150;
            options.VerticalResolution = 150;

            // Convert the HTML document to a PNG image using the specified DPI
            Converter.ConvertHTML(document, options, "output.png");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
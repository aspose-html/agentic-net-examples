// Use ConvertHTML with XpsRenderingOptions to produce XPS files from HTML while applying custom bottom margin.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string documentPath = "input.html";

            // Path where the XPS file will be saved
            string savePath = "output.xps";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(documentPath);

            // Create XPS conversion options
            XpsSaveOptions options = new XpsSaveOptions();

            // Set custom page size (8.5 x 11 inches) and a bottom margin of 1 inch
            options.PageSetup.AnyPage = new Page(
                new Size(Length.FromInches(8.5f), Length.FromInches(11f)),
                new Margin(0, 0, 0, 1));

            // Perform the conversion
            Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
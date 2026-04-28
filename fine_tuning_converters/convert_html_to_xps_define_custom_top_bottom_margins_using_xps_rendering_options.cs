// Convert HTML to XPS using XpsRenderingOptions to define custom top and bottom margins.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using System.Drawing;

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
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);

            // Create XPS save options
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Set background color (required to use System.Drawing.Color)
            options.BackgroundColor = System.Drawing.Color.White;

            // Define page size (8 inches width, 11 inches height) and custom top/bottom margins
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8),
                    Aspose.Html.Drawing.Length.FromInches(11)),
                new Aspose.Html.Drawing.Margin(0, 1, 0, 1)); // left, top, right, bottom margins in inches

            // Perform the conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
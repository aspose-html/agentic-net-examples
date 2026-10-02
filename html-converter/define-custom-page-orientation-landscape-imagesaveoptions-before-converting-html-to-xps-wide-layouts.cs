// Define custom page orientation landscape in ImageSaveOptions before converting HTML to XPS for wide layouts.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare HTML content
            string htmlContent = "<html><body><h1>Landscape XPS Example</h1></body></html>";
            string baseUri = "about:blank";

            // Load HTML document from string
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Configure XPS save options with landscape orientation
            XpsSaveOptions options = new XpsSaveOptions();
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            // Landscape A4 size: 11 inches width, 8.5 inches height, no margins
            options.PageSetup.AnyPage = new Page(
                new Size(Length.FromInches(11), Length.FromInches(8.5)),
                new Margin(0, 0, 0, 0));

            // Define output path
            string outputPath = Path.GetFullPath("output.xps");

            // Convert HTML to XPS
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            System.Console.WriteLine("Conversion completed successfully. Output: " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
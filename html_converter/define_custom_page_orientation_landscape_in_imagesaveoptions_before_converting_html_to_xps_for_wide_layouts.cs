// Define custom page orientation landscape in ImageSaveOptions before converting HTML to XPS for wide layouts.

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
            // Paths to input HTML and output XPS files
            string htmlPath = "input.html";
            string outputPath = "output.xps";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create XPS save options
            XpsSaveOptions options = new XpsSaveOptions();

            // Set a landscape page orientation (width > height) with zero margins
            options.PageSetup.AnyPage = new Page(
                new Size(Length.FromInches(11), Length.FromInches(8)),
                new Margin(0, 0, 0, 0));

            // Convert HTML to XPS using the configured options
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
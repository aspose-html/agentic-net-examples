// Fine‑tune the page orientation in XpsSaveOptions when converting Markdown to landscape XPS.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content (could be generated from Markdown)
            string htmlContent = "<html><body><h1>Sample Document</h1><p>This is a test.</p></body></html>";
            // Load HTML document from inline content
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure XPS save options for landscape orientation
            var options = new Aspose.Html.Saving.XpsSaveOptions();
            options.BackgroundColor = System.Drawing.Color.AliceBlue;
            // Landscape page: width 11 inches, height 8.5 inches, no margins
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(11),
                    Aspose.Html.Drawing.Length.FromInches(8.5)),
                new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

            // Output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.xps");

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
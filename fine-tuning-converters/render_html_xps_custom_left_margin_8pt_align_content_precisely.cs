// Render HTML to XPS with custom left margin of 8 points to align content precisely.

using System;
using System.Drawing;
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
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Configure XPS save options
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            options.BackgroundColor = System.Drawing.Color.White;

            // Define page size (8.5 x 11 inches) and custom left margin of 8 points
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5),
                Aspose.Html.Drawing.Length.FromInches(11));

            Aspose.Html.Drawing.Margin pageMargin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromPoints(8),   // left margin
                Aspose.Html.Drawing.Length.FromPoints(0),   // top margin
                Aspose.Html.Drawing.Length.FromPoints(0),   // right margin
                Aspose.Html.Drawing.Length.FromPoints(0));  // bottom margin

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, pageMargin);
            options.PageSetup.AnyPage = page;

            // Output XPS file path
            string outputPath = "output.xps";

            // Convert HTML to XPS
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("HTML successfully rendered to XPS at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Render HTML to XPS with custom left margin of 10 millimeters by adjusting XpsRenderingOptions.MarginLeft.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlContent = "<html><body><h1>Hello XPS</h1></body></html>";
            string inputPath = "sample.html";
            File.WriteAllText(inputPath, htmlContent);

            // Output XPS file path
            string outputPath = "output.xps";

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Configure XPS save options
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            options.BackgroundColor = System.Drawing.Color.White;

            // Define page size (8.5 x 11 inches) and left margin of 10 millimeters
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5),
                Aspose.Html.Drawing.Length.FromInches(11));

            int leftMarginPx = (int)Aspose.Html.Drawing.Length.FromMillimeters(10)
                .GetValue(Aspose.Html.Drawing.UnitType.Px);

            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                leftMarginPx, // left
                0,            // top
                0,            // right
                0);           // bottom

            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(pageSize, margin);

            // Convert HTML to XPS
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}
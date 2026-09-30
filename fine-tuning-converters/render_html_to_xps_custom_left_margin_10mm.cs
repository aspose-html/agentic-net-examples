// Render HTML to XPS with custom left margin of 10 millimeters by adjusting XpsRenderingOptions.MarginLeft.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string documentPath = "sample.html";
            string savePath = "output.xps";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(documentPath))
            {
                File.WriteAllText(documentPath, "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath);

            // Configure XPS save options with custom left margin (10 millimeters ≈ 0.3937 inches)
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            options.BackgroundColor = System.Drawing.Color.White;

            // Set page size (8.5 x 11 inches) and margins (left margin ~10 mm, others zero)
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5),
                Aspose.Html.Drawing.Length.FromInches(11));

            // Left margin 10 mm ≈ 0.3937 inches
            Aspose.Html.Drawing.Margin margins = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(0.3937), // left
                Aspose.Html.Drawing.Length.FromInches(0),      // top
                Aspose.Html.Drawing.Length.FromInches(0),      // right
                Aspose.Html.Drawing.Length.FromInches(0));     // bottom

            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(pageSize, margins);

            // Convert HTML to XPS
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
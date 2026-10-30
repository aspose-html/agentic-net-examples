// Set PDF page margins using PdfSaveOptions.MarginTop, MarginBottom, MarginLeft, and MarginRight before conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure PDF save options with custom margins
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Define page size (A4) using inches
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.27),
                Aspose.Html.Drawing.Length.FromInches(11.69));

            // Define margins (1 inch on each side)
            Aspose.Html.Drawing.Margin margins = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(1.0), // top
                Aspose.Html.Drawing.Length.FromInches(1.0), // right
                Aspose.Html.Drawing.Length.FromInches(1.0), // bottom
                Aspose.Html.Drawing.Length.FromInches(1.0)  // left
            );

            // Apply page setup with the defined size and margins
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margins);
            options.PageSetup.AnyPage = page;

            // Convert HTML to PDF with the specified options
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
// Configure PdfSaveOptions with custom margins, then convert an HTML file containing canvas to PDF.

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
            // Paths to the source HTML file (containing a canvas) and the output PDF file
            string inputPath = "input.html";
            string outputPath = "output.pdf";

            // Load the HTML document from the file system
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create PDF save options instance
            PdfSaveOptions options = new PdfSaveOptions();

            // Define page size (8.5 x 11 inches) using Length.FromInches
            Size pageSize = new Size(Length.FromInches(8.5f), Length.FromInches(11f));

            // Define custom margins (top, right, bottom, left) in points (here using 1 point for simplicity)
            Margin pageMargin = new Margin(1, 1, 1, 1);

            // Assemble the page layout with size and margins
            Page page = new Page(pageSize, pageMargin);

            // Assign the custom page to the PDF options
            options.PageSetup.AnyPage = page;

            // Convert the HTML document to PDF using the configured options
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
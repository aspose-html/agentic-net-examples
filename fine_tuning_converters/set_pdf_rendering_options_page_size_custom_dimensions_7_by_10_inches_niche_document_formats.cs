// Set PdfRenderingOptions.PageSize to custom dimensions of 7 by 10 inches for niche document formats.

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
            // Paths to the source HTML file and the destination PDF file
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create PDF save options
            PdfSaveOptions options = new PdfSaveOptions();

            // Define a custom page size of 7 x 10 inches
            Size pageSize = new Size(Length.FromInches(7f), Length.FromInches(10f));

            // Define margins (all set to zero for this example)
            Margin margin = new Margin(0, 0, 0, 0);

            // Create a page with the custom size and margins
            Page page = new Page(pageSize, margin);

            // Apply the custom page to the PDF options
            options.PageSetup.AnyPage = page;

            // Convert the HTML document to PDF using the configured options
            Converter.ConvertHTML(document, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Set PdfSaveOptions.PageSize and Margin before converting HTML to PDF to control page layout.

using System;
using System.IO;
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
            // Define input and output paths
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello, PDF!</h1></body></html>");
            }

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Configure PDF save options with custom page size and margins
            PdfSaveOptions options = new PdfSaveOptions();

            // Page size: 8.5 x 11 inches (Letter)
            Size pageSize = new Size(
                Length.FromInches(8.5f),
                Length.FromInches(11f)
            );

            // Margins: 0.5 inch on all sides
            Margin pageMargin = new Margin(
                Length.FromInches(0.5),
                Length.FromInches(0.5),
                Length.FromInches(0.5),
                Length.FromInches(0.5)
            );

            // Create page setup
            Page page = new Page(pageSize, pageMargin);
            options.PageSetup.AnyPage = page;

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("PDF conversion completed successfully. Output file: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during PDF conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}
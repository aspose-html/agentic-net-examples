// Set custom page margins of 0.5 inches in PdfSaveOptions before converting a long HTML document to PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML and output PDF paths
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Long Document</h1><p>This is a sample long HTML document.</p></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Create PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Define page size (Letter: 8.5 x 11 inches)
            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromInches(8.5),
                Aspose.Html.Drawing.Length.FromInches(11));

            // Define margins of 0.5 inches on all sides
            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(0.5), // top
                Aspose.Html.Drawing.Length.FromInches(0.5), // right
                Aspose.Html.Drawing.Length.FromInches(0.5), // bottom
                Aspose.Html.Drawing.Length.FromInches(0.5)  // left
            );

            // Create page setup
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
            options.PageSetup.AnyPage = page;

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("PDF conversion completed successfully. Output file: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
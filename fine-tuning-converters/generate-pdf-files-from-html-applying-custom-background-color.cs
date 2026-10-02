// Use ConvertHTML with PdfRenderingOptions to generate PDF files from HTML while applying a custom background color.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input HTML content and file paths
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, PDF with custom background!</h1></body></html>";
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // Write HTML content to a file
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document from the file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure PDF save options with custom background color
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            Console.WriteLine("PDF generated successfully at: " + Path.GetFullPath(pdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
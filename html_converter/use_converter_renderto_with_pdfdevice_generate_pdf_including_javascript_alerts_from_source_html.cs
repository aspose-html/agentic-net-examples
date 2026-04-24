// Use Converter.RenderTo with PdfDevice to generate a PDF that includes JavaScript alerts from the source HTML.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file that contains JavaScript alerts
            string htmlPath = "input.html";

            // Desired output PDF file path
            string pdfPath = "output.pdf";

            // Create a configuration (default allows script execution)
            Configuration config = new Configuration();

            // Load the HTML document with the configuration
            HTMLDocument document = new HTMLDocument(htmlPath, config);

            // Initialize PDF save options (default settings)
            PdfSaveOptions pdfOptions = new PdfSaveOptions();

            // Convert the HTML document to PDF; scripts (e.g., alerts) will be processed
            Converter.ConvertHTML(document, pdfOptions, pdfPath);

            Console.WriteLine("PDF generated successfully at: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}
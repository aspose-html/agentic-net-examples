// Dispose of HtmlDocument and PdfSaveOptions objects after each conversion to free unmanaged resources promptly.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string outputPath = "output.pdf";

            // Configure security settings
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Load HTML content
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(html, config);

            // Set PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(doc, options, outputPath);

            // Dispose of unmanaged resources
            doc.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
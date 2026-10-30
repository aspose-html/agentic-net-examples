// Convert website pages to HTML and simultaneously generate PDF snapshots for archival purposes.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input URL
            string url = "https://example.com";

            // Output file paths
            string htmlOutputPath = "example.html";
            string pdfOutputPath = "example.pdf";

            // Load the web page
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);

            // Save the HTML snapshot
            document.Save(htmlOutputPath);

            // Convert and save PDF snapshot
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, pdfOutputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
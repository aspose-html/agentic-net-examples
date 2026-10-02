// Convert website pages to HTML and simultaneously generate PDF snapshots for archival purposes.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input URL of the website page
            string url = "https://example.com";

            // Output file paths
            string htmlOutputPath = "example.html";
            string pdfOutputPath = "example.pdf";

            // Load the web page into an HTMLDocument
            HTMLDocument document = new HTMLDocument(url);

            // Save the HTML content to a file
            document.Save(htmlOutputPath);

            // Prepare PDF conversion options
            PdfSaveOptions pdfOptions = new PdfSaveOptions();

            // Convert the HTMLDocument to PDF and save
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, pdfOutputPath);

            Console.WriteLine("HTML saved to: " + Path.GetFullPath(htmlOutputPath));
            Console.WriteLine("PDF snapshot saved to: " + Path.GetFullPath(pdfOutputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
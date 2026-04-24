// Allow custom User-Agent header configuration for HttpClient requests.

using System;
using System.Net.Http;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the HTML page to convert
            string url = "https://example.com";

            // Create HttpClient and set a custom User-Agent header
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("MyCustomAgent/1.0");

                // Download the HTML content
                string htmlContent = client.GetStringAsync(url).Result;

                // Load the HTML content into an Aspose.HTML document
                HTMLDocument document = new HTMLDocument(htmlContent, url);

                // Define PDF output path and conversion options
                string pdfPath = "output.pdf";
                PdfSaveOptions options = new PdfSaveOptions();

                // Convert the HTML document to PDF
                Converter.ConvertHTML(document, options, pdfPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
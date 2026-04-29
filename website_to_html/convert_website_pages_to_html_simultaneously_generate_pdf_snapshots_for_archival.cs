// Convert website pages to HTML and simultaneously generate PDF snapshots for archival purposes.

using System;
using System.IO;
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
            string[] urls = { "https://example.com", "https://example.org" };
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);
            using (HttpClient client = new HttpClient())
            {
                foreach (string url in urls)
                {
                    string htmlContent = client.GetStringAsync(url).Result;
                    Uri uri = new Uri(url);
                    string fileBase = string.IsNullOrWhiteSpace(Path.GetFileName(uri.AbsolutePath)) ? "index" : Path.GetFileNameWithoutExtension(uri.AbsolutePath);
                    string htmlPath = Path.Combine(outputDir, fileBase + ".html");
                    File.WriteAllText(htmlPath, htmlContent);
                    HTMLDocument document = new HTMLDocument(url);
                    PdfSaveOptions options = new PdfSaveOptions();
                    string pdfPath = Path.Combine(outputDir, fileBase + ".pdf");
                    Converter.ConvertHTML(document, options, pdfPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
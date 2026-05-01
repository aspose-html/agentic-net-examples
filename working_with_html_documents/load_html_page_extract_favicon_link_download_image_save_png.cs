// Load an HTML page, extract its favicon link, download the image, and save as PNG.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string pageUrl = args.Length > 0 ? args[0] : "https://example.com";
            using var httpClient = new HttpClient();

            // Load HTML content
            string htmlContent = await httpClient.GetStringAsync(pageUrl);

            // Parse HTML with Aspose.HTML
            var document = new HTMLDocument(htmlContent, pageUrl);

            // Find favicon link element
            var linkElement = document.QuerySelector("link[rel~='icon']") as Element;
            if (linkElement == null)
            {
                Console.WriteLine("Favicon link not found.");
                return;
            }

            string href = linkElement.GetAttribute("href");
            if (string.IsNullOrEmpty(href))
            {
                Console.WriteLine("Favicon href attribute is empty.");
                return;
            }

            // Resolve absolute URL of the favicon
            var faviconUri = new Uri(new Uri(pageUrl), href);
            string faviconUrl = faviconUri.ToString();

            // Download favicon image
            byte[] imageBytes = await httpClient.GetByteArrayAsync(faviconUrl);

            // Save as PNG
            string outputPath = "favicon.png";
            File.WriteAllBytes(outputPath, imageBytes);
            Console.WriteLine($"Favicon saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
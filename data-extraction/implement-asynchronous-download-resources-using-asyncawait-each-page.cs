// Implement asynchronous download of resources using async/await for each page.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string[] urls = new string[]
            {
                "https://example.com",
                "https://www.wikipedia.org"
            };

            foreach (string url in urls)
            {
                string html = await DownloadPageAsync(url);
                // Load HTML content into Aspose.HTML document
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, new Aspose.Html.Url(url)))
                {
                    string title = document.Title ?? "(no title)";
                    Console.WriteLine($"URL: {url}");
                    Console.WriteLine($"Title: {title}");
                    Console.WriteLine($"Content length: {html.Length}");
                    Console.WriteLine(new string('-', 40));
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task<string> DownloadPageAsync(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            client.Timeout = TimeSpan.FromSeconds(30);
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
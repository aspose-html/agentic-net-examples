// Use a retry‑after header from HTTP response to schedule delayed retries for rate‑limited resources.

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static async Task Main()
    {
        try
        {
            string url = "https://example.com/resource";
            string html = await LoadHtmlWithRetryAsync(url, maxAttempts: 5);
            // Load the HTML content into Aspose.HTML document
            HTMLDocument document = new HTMLDocument(html, url);
            // Output the outer HTML to console
            Console.WriteLine(((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Loads HTML from a URL handling HTTP 429 responses using the Retry-After header
    private static async Task<string> LoadHtmlWithRetryAsync(string url, int maxAttempts)
    {
        using var httpClient = new HttpClient();
        int attempt = 0;

        while (true)
        {
            attempt++;
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.StatusCode == (HttpStatusCode)429 && attempt < maxAttempts)
            {
                // Try to read Retry-After header
                if (response.Headers.RetryAfter != null)
                {
                    TimeSpan delay;
                    if (response.Headers.RetryAfter.Delta.HasValue)
                    {
                        delay = response.Headers.RetryAfter.Delta.Value;
                    }
                    else if (response.Headers.RetryAfter.Date.HasValue)
                    {
                        delay = response.Headers.RetryAfter.Date.Value - DateTimeOffset.UtcNow;
                        if (delay < TimeSpan.Zero) delay = TimeSpan.Zero;
                    }
                    else
                    {
                        // Default fallback delay
                        delay = TimeSpan.FromSeconds(5);
                    }
                    await Task.Delay(delay);
                    continue; // retry
                }
                else
                {
                    // No Retry-After header, use default delay
                    await Task.Delay(TimeSpan.FromSeconds(5));
                    continue;
                }
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
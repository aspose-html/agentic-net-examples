// Use asynchronous loading to improve performance when converting multiple websites concurrently.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
                "https://example.org",
                "https://example.net"
            };

            Task<string>[] loadTasks = urls.Select(url => LoadHtmlAsync(url)).ToArray();

            string[] results = await Task.WhenAll(loadTasks);

            for (int i = 0; i < urls.Length; i++)
            {
                Console.WriteLine($"Content from {urls[i]}:");
                Console.WriteLine(results[i]);
                Console.WriteLine(new string('-', 80));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static Task<string> LoadHtmlAsync(string url)
    {
        return Task.Run(() =>
        {
            using (System.Threading.AutoResetEvent resetEvent = new System.Threading.AutoResetEvent(false))
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument())
            {
                string htmlResult = string.Empty;

                document.OnReadyStateChange += (sender, e) =>
                {
                    if (document.ReadyState == "complete")
                    {
                        htmlResult = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                        resetEvent.Set();
                    }
                };

                document.Navigate(url);
                resetEvent.WaitOne();

                return htmlResult;
            }
        });
    }
}
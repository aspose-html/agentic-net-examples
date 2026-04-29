// Use asynchronous loading to improve performance when converting multiple websites concurrently.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Html;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            var urls = new List<string>
            {
                "https://www.example.com",
                "https://www.wikipedia.org",
                "https://www.microsoft.com"
            };

            var tasks = new List<Task<string>>();
            foreach (var url in urls)
            {
                tasks.Add(Task.Run(() => LoadHtml(url)));
            }

            var results = await Task.WhenAll(tasks);
            foreach (var html in results)
            {
                Console.WriteLine(html);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static string LoadHtml(string url)
    {
        using (AutoResetEvent resetEvent = new AutoResetEvent(false))
        using (HTMLDocument document = new HTMLDocument())
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
    }
}
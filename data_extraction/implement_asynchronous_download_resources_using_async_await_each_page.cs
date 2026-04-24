// Implement asynchronous download of resources using async/await for each page.

using System;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // List of page URLs to download resources from
            string[] pageUrls = new string[]
            {
                "https://example.com/page1.html",
                "https://example.com/page2.html"
            };

            foreach (var url in pageUrls)
            {
                // Asynchronously download the page content as a byte array
                byte[] data = await DownloadResourceAsync(url);
                if (data != null)
                {
                    Console.WriteLine($"Downloaded {url} - {data.Length} bytes");
                }
                else
                {
                    Console.WriteLine($"Failed to download {url}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Asynchronously downloads a resource using Aspose.HTML network APIs
    private static async Task<byte[]> DownloadResourceAsync(string urlString)
    {
        // Create a blank HTMLDocument to obtain a network context
        HTMLDocument document = new HTMLDocument();

        // Create a Url object for the target resource
        Url url = new Url(urlString);

        // Build a request message for the URL
        RequestMessage request = new RequestMessage(url);

        // Send the request synchronously inside a Task to avoid blocking
        ResponseMessage response = await Task.Run(() => document.Context.Network.Send(request));

        // Check if the request succeeded
        bool isSuccess = response.IsSuccess;
        if (!isSuccess)
        {
            return null;
        }

        // Read the response content as a byte array
        byte[] contentBytes = response.Content.ReadAsByteArray();
        return contentBytes;
    }
}
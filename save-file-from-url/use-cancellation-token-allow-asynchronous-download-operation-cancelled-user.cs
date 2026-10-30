// Use a cancellation token to allow the asynchronous download operation to be cancelled by the user.

using System;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static async Task Main()
    {
        try
        {
            string url = "https://example.com";
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await DownloadAsync(url, cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Download operation was cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static async Task DownloadAsync(string url, CancellationToken token)
    {
        // Create a document to access the network service
        using var document = new Aspose.Html.HTMLDocument();

        // Prepare request
        Aspose.Html.Url uri = new Aspose.Html.Url(url);
        Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(uri);

        // Optionally set a request timeout
        request.Timeout = TimeSpan.FromSeconds(10);

        // Perform the request asynchronously, respecting the cancellation token
        Aspose.Html.Net.ResponseMessage response = await Task.Run(() => document.Context.Network.Send(request), token);

        if (response.IsSuccess)
        {
            byte[] contentBytes = response.Content.ReadAsByteArray();
            Console.WriteLine($"Downloaded {contentBytes.Length} bytes successfully.");
        }
        else
        {
            Console.WriteLine($"Download failed with status code: {response.StatusCode}");
        }
    }
}
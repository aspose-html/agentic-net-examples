// Use a cancellation token to allow the asynchronous download operation to be cancelled by the user.

using System;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            using var document = new HTMLDocument();
            using var cts = new CancellationTokenSource();

            Console.WriteLine("Press 'c' to cancel the download...");
            Task.Run(() =>
            {
                if (Console.ReadKey(true).KeyChar == 'c')
                    cts.Cancel();
            });

            await document.NavigateAsync("https://example.com", cts.Token);
            document.Save("downloaded.html");
            Console.WriteLine("Download completed and saved.");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Download was cancelled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
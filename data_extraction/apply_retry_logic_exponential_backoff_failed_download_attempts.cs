// Apply retry logic with exponential backoff for failed download attempts.

using System;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com/file.bin";
            var (isSuccess, data) = DownloadWithRetry(url, maxAttempts: 5, initialDelayMs: 1000);
            Console.WriteLine(isSuccess
                ? $"Download succeeded. Bytes received: {data.Length}"
                : "Download failed after retries.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    static (bool isSuccess, byte[] data) DownloadWithRetry(string urlString, int maxAttempts, int initialDelayMs)
    {
        int attempt = 0;
        while (attempt < maxAttempts)
        {
            attempt++;
            // Begin download attempt using Aspose.Html network APIs
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();
            Aspose.Html.Url url = new Aspose.Html.Url(urlString);
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);
            bool isSuccess = response.IsSuccess;
            byte[] contentBytes = response.Content.ReadAsByteArray();

            if (isSuccess)
                return (true, contentBytes);

            // If not successful and attempts remain, wait with exponential backoff
            if (attempt < maxAttempts)
            {
                int delay = initialDelayMs * (int)Math.Pow(2, attempt - 1);
                Thread.Sleep(delay);
            }
        }
        return (false, null);
    }
}
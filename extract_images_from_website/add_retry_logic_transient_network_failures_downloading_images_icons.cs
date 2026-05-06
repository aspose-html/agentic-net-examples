// Add retry logic for transient network failures when downloading images or icons.

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
            string imageUrl = "https://example.com/image.png";
            byte[] data = DownloadWithRetry(imageUrl, 3);
            Console.WriteLine($"Downloaded {data.Length} bytes.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static byte[] DownloadWithRetry(string urlString, int maxAttempts)
    {
        int attempt = 0;
        while (true)
        {
            attempt++;
            try
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();
                Aspose.Html.Url url = new Aspose.Html.Url(urlString);
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
                Aspose.Html.Net.ResponseMessage response = document.Context.Network.Send(request);
                bool isSuccess = response.IsSuccess;
                if (isSuccess)
                {
                    byte[] contentBytes = response.Content.ReadAsByteArray();
                    return contentBytes;
                }
                else
                {
                    if (attempt >= maxAttempts) throw new Exception($"Failed to download after {attempt} attempts. Status code: {response.StatusCode}");
                }
            }
            catch (Exception)
            {
                if (attempt >= maxAttempts) throw;
                // Simple backoff before retrying
                Thread.Sleep(1000 * attempt);
            }
        }
    }
}
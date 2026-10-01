// Implement a retry policy with exponential backoff for transient failures when downloading large files.

using System;
using System.IO;
using System.Net.Http;
using System.Threading;

public sealed class RetryHandler : Aspose.Html.Net.MessageHandler
{
    private readonly int _maxRetries;
    public RetryHandler(int maxRetries)
    {
        _maxRetries = maxRetries;
    }
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        for (int attempt = 0; attempt <= _maxRetries; attempt++)
        {
            Next(context);
            if ((int)context.Response.StatusCode < 500)
                break;
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Configure Aspose.HTML network service with retry handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new RetryHandler(3));

            // Example download with exponential backoff
            string url = "https://www.example.com";
            string outputPath = "example.html";
            int maxAttempts = 5;

            DownloadFileWithRetry(url, outputPath, maxAttempts);
            Console.WriteLine("Download completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void DownloadFileWithRetry(string url, string outputPath, int maxAttempts)
    {
        Exception lastException = null;
        using (HttpClient client = new HttpClient())
        {
            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    using (HttpResponseMessage response = client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).Result)
                    {
                        response.EnsureSuccessStatusCode();
                        using (Stream contentStream = response.Content.ReadAsStreamAsync().Result)
                        using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            contentStream.CopyTo(fileStream);
                        }
                    }
                    // Success, exit method
                    return;
                }
                catch (Exception ex) when (ex is HttpRequestException || ex is IOException)
                {
                    lastException = ex;
                    int delay = (int)Math.Pow(2, attempt) * 1000; // exponential backoff in milliseconds
                    Thread.Sleep(delay);
                }
            }
        }
        // All attempts failed
        throw lastException ?? new Exception("Download failed without captured exception.");
    }
}
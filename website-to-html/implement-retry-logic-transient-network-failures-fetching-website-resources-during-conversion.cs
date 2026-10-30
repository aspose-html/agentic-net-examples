// Implement retry logic for transient network failures when fetching website resources during conversion.

using System;
using System.IO;
using System.Threading;

class RetryMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly int _maxRetries;
    public RetryMessageHandler(int maxRetries)
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
            ConvertHtmlToPdfWithRetry("https://example.com", "output.pdf", 3);
            Console.WriteLine("Conversion succeeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertHtmlToPdfWithRetry(string url, string outputPath, int maxAttempts)
    {
        Exception lastException = null;
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                var configuration = new Aspose.Html.Configuration();
                var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                network.MessageHandlers.Add(new RetryMessageHandler(2));

                using (var document = new Aspose.Html.HTMLDocument(url, configuration))
                {
                    var options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }

                // Success, exit loop
                return;
            }
            catch (IOException ioEx)
            {
                lastException = ioEx;
                Thread.Sleep(1000);
            }
            catch (UnauthorizedAccessException uaEx)
            {
                lastException = uaEx;
                Thread.Sleep(1000);
            }
        }

        // If we reach here, all attempts failed
        if (lastException != null)
            throw lastException;
    }
}
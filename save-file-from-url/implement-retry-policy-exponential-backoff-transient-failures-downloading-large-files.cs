// Implement a retry policy with exponential backoff for transient failures when downloading large files.

using System;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Rendering.Pdf;

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

            int statusCode = (int)context.Response.StatusCode;
            if (statusCode < 500)
            {
                // Success or non‑transient error, stop retrying
                break;
            }

            // Transient server error, apply exponential backoff before next attempt
            int delayMilliseconds = (int)Math.Pow(2, attempt) * 1000; // 1s, 2s, 4s, ...
            Thread.Sleep(delayMilliseconds);
        }
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Input URL of a large file (HTML page) to download
            string url = "https://example.com/largefile.html";
            // Output PDF path
            string outputPath = "downloaded.pdf";
            // Maximum retry attempts
            int maxAttempts = 5;

            // Configure Aspose.HTML with the retry handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new RetryHandler(maxAttempts));

            // Load the document and render to PDF
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("Download and conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
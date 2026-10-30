// Implement a retry policy with exponential backoff for transient failures when downloading large files.

using System;
using System.IO;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Rendering.Pdf;

public sealed class TimeoutHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = System.TimeSpan.FromSeconds(30);
        Next(context);
    }
}

public class RetryHandler : Aspose.Html.Net.MessageHandler
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
                break;
            }

            // Exponential backoff: 2^attempt seconds
            int delaySeconds = (int)Math.Pow(2, attempt);
            Thread.Sleep(delaySeconds * 1000);
        }
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string inputUrl = "https://example.com/large.html";
            string outputPath = "output.pdf";
            int maxRetries = 3;

            // Create configuration and configure network service with handlers
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new TimeoutHandler());
            networkService.MessageHandlers.Add(new RetryHandler(maxRetries));

            // Load the remote HTML document using the configured handlers
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputUrl, configuration))
            {
                // Render the document to PDF
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
                {
                    document.RenderTo(device);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Implement retry logic for transient network failures when fetching website resources during conversion.

using System;
using System.IO;
using System.Net;
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
            string inputPath = "sample.mht";
            string outputPath = "output.pdf";
            int maxAttempts = 3;
            int retryDelayMs = 1000;

            // Ensure a minimal MHTML file exists
            if (!File.Exists(inputPath))
            {
                string minimalMhtml = @"From: <Saved by Outlook>
Subject: Sample
Date: Mon, 1 Jan 2024 00:00:00 +0000
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""; type=""text/html""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Hello, MHTML!</h1></body></html>

------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, minimalMhtml);
            }

            // Configure Aspose.Html with retry handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new RetryMessageHandler(maxAttempts));

            // Perform conversion with retry logic
            ConvertMhtmlToPdfWithRetry(inputPath, outputPath, maxAttempts, retryDelayMs);
            Console.WriteLine($"Conversion succeeded. PDF saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlToPdfWithRetry(string inputPath, string outputPath, int maxAttempts, int delayMilliseconds)
    {
        Exception lastException = null;

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                using (Stream stream = File.OpenRead(inputPath))
                {
                    var options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }
                // Success, exit method
                return;
            }
            catch (IOException ioEx)
            {
                lastException = ioEx;
            }
            catch (UnauthorizedAccessException uaEx)
            {
                lastException = uaEx;
            }

            // Wait before next attempt if not the last one
            if (attempt < maxAttempts)
            {
                Thread.Sleep(delayMilliseconds);
            }
        }

        // All attempts failed
        throw lastException ?? new Exception("Conversion failed without captured exception.");
    }
}
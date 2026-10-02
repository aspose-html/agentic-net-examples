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
            string url = "https://example.com";
            string outputPath = "output.pdf";
            int maxRetries = 3;

            ConvertHtmlToPdfWithRetry(url, outputPath, maxRetries);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertHtmlToPdfWithRetry(string url, string outputPath, int maxRetries)
    {
        Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
        Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
        network.MessageHandlers.Add(new RetryMessageHandler(maxRetries));

        using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
        {
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
    }
}
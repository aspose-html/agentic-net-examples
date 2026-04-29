// Implement retry logic for transient network failures when fetching website resources during conversion.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class RetryHandler : Aspose.Html.Net.MessageHandler
{
    private readonly int _maxRetries;
    public RetryHandler(int maxRetries) { _maxRetries = maxRetries; }
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Retry the request while the response indicates a server error (status >= 500)
        for (int attempt = 0; attempt <= _maxRetries; attempt++)
        {
            Next(context);
            if ((int)context.Response.StatusCode < 500) break;
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and register the retry handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new RetryHandler(3));

            // Load the HTML document from a URL using the configured retry logic
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                // Convert the loaded document to PDF
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.pdf");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
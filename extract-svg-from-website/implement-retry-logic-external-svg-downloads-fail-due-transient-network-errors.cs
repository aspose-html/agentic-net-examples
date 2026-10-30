// Implement retry logic for external SVG downloads that fail due to transient network errors.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the external SVG file
            string svgUrl = "https://example.com/sample.svg";
            // Output PDF path
            string outputPath = "output.pdf";

            // Create configuration and set up retry handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new RetryHandler(3));

            // Load SVG document (network request will use the retry handler)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(svgUrl, configuration))
            {
                // Set PDF save options
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                // Convert the loaded SVG (as HTMLDocument) to PDF
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine("SVG successfully converted to PDF: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}

// Message handler that retries transient network errors (HTTP status >= 500)
class RetryHandler : Aspose.Html.Net.MessageHandler
{
    private readonly int maxRetriesField;

    public RetryHandler(int maxRetries)
    {
        maxRetriesField = maxRetries;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        for (int attempt = 0; attempt <= maxRetriesField; attempt++)
        {
            Next(context);
            if ((int)context.Response.StatusCode < 500)
                break;
        }
    }
}
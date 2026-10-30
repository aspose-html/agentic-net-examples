// Throttle network requests to avoid overwhelming the target server during large‑scale website conversion.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and add throttling handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new ThrottlingHandler());

            // Prepare request to target URL
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com");

            // Load document with custom configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // Convert to MHTML as an example output format
                Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();
                string outputPath = "output.mhtml";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Message handler that introduces a delay between network requests to throttle traffic
class ThrottlingHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Simple fixed delay (e.g., 200 milliseconds) before proceeding with the request
        System.Threading.Thread.Sleep(200);
        Next(context);
    }
}
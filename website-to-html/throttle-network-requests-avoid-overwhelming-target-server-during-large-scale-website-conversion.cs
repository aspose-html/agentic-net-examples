// Throttle network requests to avoid overwhelming the target server during large‑scale website conversion.

using System;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and add throttling handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new ThrottleHandler());

            // Prepare request to the target website
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com");

            // Load the document using the request and configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // Set save options (MHTML format)
                Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();

                // Define output path
                string outputPath = "output.mhtml";

                // Convert and save
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Message handler that introduces a delay between network requests
class ThrottleHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Throttle: wait 200 milliseconds before proceeding
        Thread.Sleep(200);
        Next(context);
    }
}
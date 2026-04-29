// Add custom error handling for network timeouts via a timeout‑error handler.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

public sealed class TimeoutHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Set a custom timeout of 10 seconds for each network request
        context.Request.Timeout = TimeSpan.FromSeconds(10);
        // Continue processing the request
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create a configuration instance
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Obtain the network service from the configuration
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Register the custom timeout handler
            networkService.MessageHandlers.Add(new TimeoutHandler());

            // Load the HTML document using the configuration with the custom handler
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                // Example operation: convert the loaded document to PDF
                Aspose.Html.Converters.Converter.ConvertHTML(document, new PdfSaveOptions(), "output.pdf");
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
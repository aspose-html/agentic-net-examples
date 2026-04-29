// Create a custom message handler that logs request URLs and execution times for each HTTP call.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // Create a configuration instance
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Retrieve the network service from the configuration
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Register the custom timing handler
            networkService.MessageHandlers.Add(new TimingMessageHandler());

            // Load an HTML document; the handler will log each request
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                // Document processing can be done here if needed
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom message handler that logs request URL and execution time
public sealed class TimingMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        System.DateTime startTime = System.DateTime.UtcNow;
        // Continue processing the request
        Next(context);
        System.DateTime endTime = System.DateTime.UtcNow;
        System.TimeSpan elapsed = endTime - startTime;

        System.Diagnostics.Debug.WriteLine("Request: " + context.Request.RequestUri);
        System.Diagnostics.Debug.WriteLine("Start: " + startTime.ToString("O"));
        System.Diagnostics.Debug.WriteLine("End: " + endTime.ToString("O"));
        System.Diagnostics.Debug.WriteLine("Elapsed: " + elapsed.TotalMilliseconds + " ms");
    }
}
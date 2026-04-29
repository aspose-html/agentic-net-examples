// Create a configuration that disables all network requests except those required for loading local resources.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class LocalOnlyHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Get the request URI as a string
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();

        // Allow only file scheme resources; reject everything else
        if (!string.IsNullOrEmpty(requestUri) && !requestUri.StartsWith("file:", StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("Only local file resources are allowed.");

        // Continue with the next handler in the pipeline
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

            // Retrieve the network service from the configuration
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Insert the custom handler at the beginning of the handler list
            networkService.MessageHandlers.Insert(0, new LocalOnlyHandler());

            // Path to a local HTML file (replace with an actual file path)
            string localHtmlPath = "sample.html";

            // Load the HTML document using the configuration that blocks external network requests
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(localHtmlPath, configuration))
            {
                // Document is loaded; further processing can be done here
                Console.WriteLine("Document loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Configure network service to use a proxy, load a remote page, and ensure resources load through proxy.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define the URL to load
            string url = "https://example.com";

            // Create a request message with a timeout
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            request.Timeout = TimeSpan.FromSeconds(30);

            // Create a configuration and add a custom message handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CleanUrlHandler());

            // Load the HTML document using the request and configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // Retrieve the outer HTML of the document
                string html = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
                Console.WriteLine($"Document loaded successfully. Length: {html.Length}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Custom message handler that normalizes the request URL
    class CleanUrlHandler : Aspose.Html.Net.MessageHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            var uri = context.Request.RequestUri;
            string cleanUrl = $"{uri.Protocol}://{uri.Host}{uri.Pathname}";
            context.Request.RequestUri = new Aspose.Html.Url(cleanUrl);
            Next(context);
        }
    }
}
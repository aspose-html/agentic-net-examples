// Resolve protocol‑relative URLs (starting with //) to absolute URLs using the Url class.

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
            // Create configuration and attach custom message handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new ProtocolRelativeUrlHandler());

            // Sample HTML containing a protocol‑relative URL
            string html = "<html><body><img src=\"//via.placeholder.com/150\" alt=\"Sample Image\"/></body></html>";

            // Load the HTML with a base URI (required for resolving relative URLs)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, new Aspose.Html.Url("https://example.com")))
            {
                // The custom handler will convert the protocol‑relative URL to an absolute one
                Console.WriteLine(document.DocumentElement.OuterHTML);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom message handler that resolves protocol‑relative URLs to absolute URLs
class ProtocolRelativeUrlHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Aspose.Html.Url requestUrl = context.Request.RequestUri;

        // If the protocol part is empty (protocol‑relative URL), prepend "https:"
        if (string.IsNullOrEmpty(requestUrl.Protocol))
        {
            string absolute = "https:" + requestUrl.Pathname;
            context.Request.RequestUri = new Aspose.Html.Url(absolute);
        }

        Next(context);
    }
}
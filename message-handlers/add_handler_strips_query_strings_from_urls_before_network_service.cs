// Add a handler that strips query strings from URLs before they are passed to the network service.

using System;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service and add the custom handler
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new QueryStringStripHandler());

            // Sample HTML containing a URL with a query string
            string htmlContent = "<html><body><img src='https://example.com/image.png?version=1'></body></html>";

            // Load the document using the configuration with the handler attached
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, configuration);

            // Save the resulting document
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Custom message handler that strips query strings from URLs
public class QueryStringStripHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string cleanUrl = context.Request.RequestUri.Protocol + "//" + context.Request.RequestUri.Host + context.Request.RequestUri.Pathname;
        context.Request.RequestUri = new Aspose.Html.Url(cleanUrl);
        Next(context);
    }
}
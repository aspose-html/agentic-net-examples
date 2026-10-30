// Design a short‑circuit handler that returns immediate response when specific query parameter is present.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service and add custom handler
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new QueryParameterShortCircuitHandler());

            // Load a document with a query parameter that triggers short‑circuit
            string url = "https://example.com?skip=true";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                // If the handler short‑circuits, the document may be empty; just output a message
                System.Console.WriteLine("Document loaded. Title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom message handler that short‑circuits when a specific query parameter is present
class QueryParameterShortCircuitHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string uriText = context.Request.RequestUri.ToString();
        if (uriText.Contains("skip"))
        {
            // Immediate response – do not continue processing
            return;
        }
        // Continue with the next handler in the pipeline
        Next(context);
    }
}
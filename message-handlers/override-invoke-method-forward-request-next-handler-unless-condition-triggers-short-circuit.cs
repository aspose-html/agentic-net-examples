// Override Invoke method to forward request to next handler unless condition triggers short‑circuit.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class MyHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string uriText = context.Request.RequestUri.ToString();
        if (uriText.Contains("blocked"))
            return;
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and obtain network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add custom message handler
            network.MessageHandlers.Add(new MyHandler());

            // Load a sample HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                // Output the document title
                Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
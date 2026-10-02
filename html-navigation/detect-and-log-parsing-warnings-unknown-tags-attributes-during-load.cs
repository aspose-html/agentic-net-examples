// Detect and log any parsing warnings such as unknown tags or attributes during load.

using System;
using System.Net;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><title>Test</title></head><body><unknownTag attr='value'>Hello</unknownTag></body></html>";

            // Create configuration and add a custom message handler to capture warnings
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            Aspose.Html.Net.MessageHandlerCollection handlers = networkService.MessageHandlers;
            handlers.Insert(0, new LogMessageHandler());

            // Load the HTML document using the configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", configuration);

            // Example processing: list all element tag names
            Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("*");
            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                Console.WriteLine(element.TagName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom message handler that logs non‑OK HTTP responses as warnings
class LogMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        if (context.Response.StatusCode != HttpStatusCode.OK)
        {
            Console.WriteLine($"Warning: Request to {context.Request.RequestUri} returned status {context.Response.StatusCode}");
        }
        Next(context);
    }
}
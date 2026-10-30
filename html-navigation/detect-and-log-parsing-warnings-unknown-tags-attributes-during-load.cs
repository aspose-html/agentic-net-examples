// Detect and log any parsing warnings such as unknown tags or attributes during load.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class ParsingWarningHandler : Aspose.Html.Net.MessageHandler
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

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with an unknown tag and attribute
            string htmlContent = "<html><head><title>Test</title></head><body><unknownTag unknownAttr='value'>Hello</unknownTag></body></html>";

            // Create configuration and attach the custom warning handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            Aspose.Html.Net.MessageHandlerCollection handlers = networkService.MessageHandlers;
            handlers.Insert(0, new ParsingWarningHandler());

            // Load the HTML document using the two‑argument constructor (inline content)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", configuration);

            // Simple output to confirm document loaded
            Console.WriteLine($"Document title: {document.Title}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
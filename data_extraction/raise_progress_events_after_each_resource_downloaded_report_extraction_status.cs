// Raise progress events after each resource is downloaded to report extraction status.

using System;
using System.Diagnostics;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and insert custom progress handler
            Configuration configuration = new Configuration();
            INetworkService service = configuration.GetService<INetworkService>();
            MessageHandlerCollection handlers = service.MessageHandlers;
            handlers.Insert(0, new ResourceProgressHandler());

            // Load HTML document (replace with your actual file path)
            string documentPath = "sample.html";
            HTMLDocument document = new HTMLDocument(documentPath, configuration);

            // Subscribe to progress event to report extraction status
            document.OnProgress += (sender, args) =>
            {
                Console.WriteLine("A resource has been downloaded.");
            };

            // Save the document (optional)
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom handler that logs each request (acts as progress notification)
public class ResourceProgressHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        Next(context);
        stopwatch.Stop();
        Debug.WriteLine("Request: " + context.Request.RequestUri);
        Debug.WriteLine("Time: " + stopwatch.ElapsedMilliseconds + "ms");
    }
}
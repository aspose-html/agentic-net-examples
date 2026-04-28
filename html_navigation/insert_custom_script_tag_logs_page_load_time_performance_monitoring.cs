// Insert a custom script tag that logs page load time for performance monitoring.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Net;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and attach a custom message handler (no-op for this example)
            Configuration configuration = new Configuration();
            INetworkService service = configuration.GetService<INetworkService>();
            MessageHandlerCollection handlers = service.MessageHandlers;
            handlers.Insert(0, new TimeLoggerMessageHandler());

            // Load the HTML document
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            string documentPath = Path.Combine(dataDir, "input.html");
            HTMLDocument document = new HTMLDocument(documentPath, configuration);

            // Insert a custom script tag that logs page load time
            Element script = document.CreateElement("script");
            script.TextContent = "window.addEventListener('load',function(){console.log('Page loaded in '+performance.now()+' ms');});";
            document.Body.AppendChild(script);

            // Save the modified document
            string outputPath = Path.Combine(dataDir, "output.html");
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Simple message handler to satisfy the configuration requirement
class TimeLoggerMessageHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        // No custom logic; just continue the pipeline
        Next(context);
    }
}
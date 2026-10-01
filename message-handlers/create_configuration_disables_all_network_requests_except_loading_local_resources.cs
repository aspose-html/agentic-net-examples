// Create a configuration that disables all network requests except those required for loading local resources.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class LocalOnlyMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
        if (!string.IsNullOrEmpty(requestUri) && !requestUri.StartsWith("file:", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Only local file resources are allowed.");
        }
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Create a minimal local HTML file
            string htmlPath = "sample.html";
            File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello World</p></body></html>");

            // Configure Aspose.HTML to allow only local resources
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Insert(0, new LocalOnlyMessageHandler());

            // Load the local HTML document using the restricted configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
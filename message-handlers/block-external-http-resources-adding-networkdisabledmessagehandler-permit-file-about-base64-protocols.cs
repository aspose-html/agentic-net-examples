// Block external HTTP resources by adding a NetworkDisabledMessageHandler that permits file, about, and base64 protocols.

using System;
using System.IO;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class NetworkDisabledMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
        if (!string.IsNullOrEmpty(requestUri) &&
            !(requestUri.StartsWith("file:", StringComparison.OrdinalIgnoreCase) ||
              requestUri.StartsWith("about:", StringComparison.OrdinalIgnoreCase) ||
              requestUri.StartsWith("data:", StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException("Only file, about, and base64 (data) protocols are allowed.");
        }
        Next(context);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Prepare a minimal HTML file
            string htmlPath = "sample.html";
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Configure Aspose.HTML with the custom network handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new NetworkDisabledMessageHandler());

            // Load the HTML document using the configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                Console.WriteLine("Document loaded successfully. Title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
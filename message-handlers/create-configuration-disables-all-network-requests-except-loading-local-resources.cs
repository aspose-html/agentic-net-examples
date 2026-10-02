// Create a configuration that disables all network requests except those required for loading local resources.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Net.MessageFilters;
using Aspose.Html.Services;
using Aspose.Html.Net;

public sealed class LocalOnlyHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
        if (!string.IsNullOrEmpty(requestUri) && !requestUri.StartsWith("file:", System.StringComparison.OrdinalIgnoreCase))
        {
            throw new System.InvalidOperationException("Only local file resources are allowed.");
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
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello, Aspose.HTML!</p></body></html>");
            }

            // Configure Aspose.HTML to block non‑file network requests
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new LocalOnlyHandler());

            // Load the local HTML document using the custom configuration
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
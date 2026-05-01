// Set custom user agent, load a site that serves different content, and compare outputs.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CustomUserAgentHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        // Set a custom User-Agent header
        context.Request.Headers["User-Agent"] = "MyCustomAgent/1.0";
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            string defaultOutput = "default.html";
            string customOutput = "custom.html";

            // Load with default configuration
            var defaultConfig = new Configuration();
            using (var defaultDoc = new HTMLDocument(url, defaultConfig))
            {
                defaultDoc.Save(defaultOutput);
            }

            // Load with custom User-Agent via message handler
            var customConfig = new Configuration();
            var network = customConfig.GetService<INetworkService>();
            network.MessageHandlers.Add(new CustomUserAgentHandler());

            using (var customDoc = new HTMLDocument(url, customConfig))
            {
                customDoc.Save(customOutput);
            }

            // Compare the two saved HTML files
            string defaultContent = File.ReadAllText(defaultOutput);
            string customContent = File.ReadAllText(customOutput);

            bool areIdentical = defaultContent == customContent;
            Console.WriteLine(areIdentical
                ? "Contents are identical."
                : "Contents differ.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
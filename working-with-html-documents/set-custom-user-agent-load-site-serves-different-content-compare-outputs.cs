// Set custom user agent, load a site that serves different content, and compare outputs.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CustomUserAgentHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
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

            // Load with default user agent
            using (Aspose.Html.HTMLDocument defaultDoc = new Aspose.Html.HTMLDocument(url))
            {
                defaultDoc.Save(defaultOutput);
            }

            // Load with custom user agent
            Aspose.Html.Configuration customConfig = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = customConfig.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CustomUserAgentHandler());

            using (Aspose.Html.HTMLDocument customDoc = new Aspose.Html.HTMLDocument(url, customConfig))
            {
                customDoc.Save(customOutput);
            }

            // Compare output file sizes
            long defaultSize = new FileInfo(defaultOutput).Length;
            long customSize = new FileInfo(customOutput).Length;

            Console.WriteLine($"Default output size: {defaultSize} bytes");
            Console.WriteLine($"Custom User-Agent output size: {customSize} bytes");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
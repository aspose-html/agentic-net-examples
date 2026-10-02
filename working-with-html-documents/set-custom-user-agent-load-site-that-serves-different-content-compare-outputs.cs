// Set custom user agent, load a site that serves different content, and compare outputs.

using System;
using System.IO;
using Aspose.Html.Net;

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
            string url = "https://httpbin.org/user-agent";
            string defaultOutput = "default.html";
            string customOutput = "custom.html";

            // Load with default user agent
            Aspose.Html.Configuration defaultConfig = new Aspose.Html.Configuration();
            using (Aspose.Html.HTMLDocument defaultDoc = new Aspose.Html.HTMLDocument(url, url, defaultConfig))
            {
                defaultDoc.Save(defaultOutput);
            }

            // Load with custom user agent
            Aspose.Html.Configuration customConfig = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = customConfig.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CustomUserAgentHandler());

            using (Aspose.Html.HTMLDocument customDoc = new Aspose.Html.HTMLDocument(url, url, customConfig))
            {
                customDoc.Save(customOutput);
            }

            // Compare outputs
            string defaultContent = File.ReadAllText(defaultOutput);
            string customContent = File.ReadAllText(customOutput);

            if (defaultContent == customContent)
            {
                Console.WriteLine("Outputs are identical.");
            }
            else
            {
                Console.WriteLine("Outputs differ.");
                Console.WriteLine("Default output snippet:");
                Console.WriteLine(defaultContent.Substring(0, Math.Min(200, defaultContent.Length)));
                Console.WriteLine("Custom output snippet:");
                Console.WriteLine(customContent.Substring(0, Math.Min(200, customContent.Length)));
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}
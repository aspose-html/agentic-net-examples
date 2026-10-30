// Specify a user-agent string to mimic a particular browser during website retrieval.

using System;
using System.Threading;

class CustomUserAgentHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Headers["User-Agent"] = "MyCustomUserAgent/1.0";
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

            // Create configuration and add custom handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CustomUserAgentHandler());

            // Load the document using the custom configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string htmlResult = string.Empty;

                if (document.ReadyState == "complete")
                {
                    htmlResult = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                    Console.WriteLine(htmlResult);
                }
                else
                {
                    using (AutoResetEvent resetEvent = new AutoResetEvent(false))
                    {
                        document.OnReadyStateChange += (sender, e) =>
                        {
                            if (document.ReadyState == "complete")
                            {
                                htmlResult = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                                resetEvent.Set();
                            }
                        };

                        // Wait for the document to finish loading (30‑second timeout)
                        if (!resetEvent.WaitOne(TimeSpan.FromSeconds(30)))
                        {
                            Console.WriteLine("Loading timed out.");
                        }
                        else
                        {
                            Console.WriteLine(htmlResult);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
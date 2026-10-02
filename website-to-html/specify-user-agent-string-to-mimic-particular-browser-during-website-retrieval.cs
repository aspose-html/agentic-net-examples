// Specify a user-agent string to mimic a particular browser during website retrieval.

using System;
using System.Threading;

class UserAgentHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0 Safari/537.36";
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

            // Configure network service with custom User-Agent handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new UserAgentHandler());

            // Load the document from the URL using the configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string htmlResult = string.Empty;

                // If the document is already loaded, capture the HTML immediately
                if (document.ReadyState == "complete")
                {
                    htmlResult = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                }
                else
                {
                    // Otherwise wait for the document to finish loading
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

                        // Wait for the load to complete (timeout to avoid indefinite block)
                        resetEvent.WaitOne(TimeSpan.FromSeconds(30));
                    }
                }

                Console.WriteLine(htmlResult);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}
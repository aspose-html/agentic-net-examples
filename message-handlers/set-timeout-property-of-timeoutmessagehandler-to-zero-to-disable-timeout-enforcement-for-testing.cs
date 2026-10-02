// Set the Timeout property of TimeoutMessageHandler to zero to disable timeout enforcement for testing.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

namespace Example
{
    public sealed class ZeroTimeoutHandler : Aspose.Html.Net.MessageHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            context.Request.Timeout = System.TimeSpan.Zero;
            Next(context);
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Create configuration and obtain network service
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                INetworkService networkService = configuration.GetService<INetworkService>();

                // Add the custom handler that disables timeout
                networkService.MessageHandlers.Add(new ZeroTimeoutHandler());

                // Create a request message (example URL)
                RequestMessage request = new RequestMessage("https://example.com");

                // Load the document using the request
                using (HTMLDocument document = new HTMLDocument(request))
                {
                    string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                    System.Console.WriteLine(html);
                }
            }
            catch (TimeoutException)
            {
                System.Console.WriteLine("The request timed out.");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
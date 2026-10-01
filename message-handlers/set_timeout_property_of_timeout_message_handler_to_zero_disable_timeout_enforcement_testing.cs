// Set the Timeout property of TimeoutMessageHandler to zero to disable timeout enforcement for testing.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

namespace Example
{
    public sealed class TimeoutMessageHandler : Aspose.Html.Net.MessageHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            context.Request.Timeout = System.TimeSpan.Zero;
            Next(context);
        }
    }

    public class Program
    {
        public static void Main()
        {
            try
            {
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
                networkService.MessageHandlers.Add(new TimeoutMessageHandler());

                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com");
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
                {
                    string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                    Console.WriteLine(html);
                }
            }
            catch (System.TimeoutException)
            {
                Console.WriteLine("The request timed out.");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
// Set the Timeout property of TimeoutMessageHandler to zero to disable timeout enforcement for testing.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class ZeroTimeoutHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        context.Request.Timeout = TimeSpan.FromSeconds(0);
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Configuration configuration = new Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Add(new ZeroTimeoutHandler());

            using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
            {
                Console.WriteLine("Document loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Create a Configuration instance with a 30‑second network timeout for all handlers.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class TimeoutHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = System.TimeSpan.FromSeconds(30);
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service and add timeout handler
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new TimeoutHandler());

            Console.WriteLine("Configuration created with 30-second network timeout for all handlers.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
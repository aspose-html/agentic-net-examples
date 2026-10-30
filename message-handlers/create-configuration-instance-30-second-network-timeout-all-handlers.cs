// Create a Configuration instance with a 30‑second network timeout for all handlers.

using System;

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
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new TimeoutHandler());

            // Example usage: load a simple document with the custom configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("about:blank", configuration);
            System.Console.WriteLine("HTMLDocument loaded with a 30‑second network timeout.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
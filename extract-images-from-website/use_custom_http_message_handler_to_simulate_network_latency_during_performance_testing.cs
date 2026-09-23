// Use custom HttpMessageHandler to simulate network latency during performance testing.

using System;
using System.Diagnostics;

public sealed class LatencyMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        DateTime startTime = DateTime.UtcNow;
        Next(context);
        DateTime endTime = DateTime.UtcNow;
        TimeSpan elapsed = endTime - startTime;
        Debug.WriteLine("Request: " + context.Request.RequestUri);
        Debug.WriteLine("Start: " + startTime.ToString("O"));
        Debug.WriteLine("End: " + endTime.ToString("O"));
        Debug.WriteLine("Elapsed: " + elapsed.TotalMilliseconds + " ms");
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
            networkService.MessageHandlers.Add(new LatencyMessageHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                Console.WriteLine("Document loaded. Title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
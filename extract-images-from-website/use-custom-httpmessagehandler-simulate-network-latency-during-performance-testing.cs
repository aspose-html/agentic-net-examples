// Use custom HttpMessageHandler to simulate network latency during performance testing.

public sealed class LatencyMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        System.DateTime startTime = System.DateTime.UtcNow;
        Next(context);
        System.DateTime endTime = System.DateTime.UtcNow;
        System.TimeSpan elapsed = endTime - startTime;
        System.Diagnostics.Debug.WriteLine("Request: " + context.Request.RequestUri);
        System.Diagnostics.Debug.WriteLine("Start: " + startTime.ToString("O"));
        System.Diagnostics.Debug.WriteLine("End: " + endTime.ToString("O"));
        System.Diagnostics.Debug.WriteLine("Elapsed: " + elapsed.TotalMilliseconds + " ms");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new LatencyMessageHandler());

            using (var document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                System.Console.WriteLine("Title: " + document.Title);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
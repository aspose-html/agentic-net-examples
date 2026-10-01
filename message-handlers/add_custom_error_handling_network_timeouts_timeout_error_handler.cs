// Add custom error handling for network timeouts via a timeout‑error handler.

public sealed class TimeoutHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = System.TimeSpan.FromSeconds(5);
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

            string url = "https://example.com";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                System.Console.WriteLine(html);
            }
        }
        catch (System.TimeoutException)
        {
            System.Console.WriteLine("The request timed out.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
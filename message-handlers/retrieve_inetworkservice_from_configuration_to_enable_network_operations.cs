// Retrieve the INetworkService from the Configuration object to enable network operations.

public sealed class NetworkLoggerHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Collections.Generic.List<string> _messages = new System.Collections.Generic.List<string>();
    public System.Collections.Generic.IReadOnlyList<string> Messages => _messages.AsReadOnly();
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        _messages.Add("Request " + context.Request.RequestUri + " returned status " + context.Response.StatusCode);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            NetworkLoggerHandler handler = new NetworkLoggerHandler();
            networkService.MessageHandlers.Add(handler);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                System.Console.WriteLine("Document title: " + document.Title);
            }

            foreach (string message in handler.Messages)
            {
                System.Console.WriteLine(message);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
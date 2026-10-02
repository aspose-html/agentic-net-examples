// Implement a retry mechanism when validating remote HTML content that may experience transient network failures.

using System;
using System.Net;

class RetryMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly int _maxRetries;
    public RetryMessageHandler(int maxRetries) { _maxRetries = maxRetries; }
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        for (int attempt = 0; attempt <= _maxRetries; attempt++)
        {
            Next(context);
            if ((int)context.Response.StatusCode < 500) break;
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new RetryMessageHandler(3));

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            request.Timeout = TimeSpan.FromSeconds(10);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                string html = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
                Console.WriteLine(html);
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("network"))
            {
                Console.WriteLine("Network error occurred while loading the HTML content.");
            }
            else
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
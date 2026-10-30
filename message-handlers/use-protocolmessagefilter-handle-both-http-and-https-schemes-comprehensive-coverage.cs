// Use ProtocolMessageFilter to handle both "http" and "https" schemes for comprehensive coverage.

using System;

class HttpHttpsHandler : Aspose.Html.Net.MessageHandler
{
    public HttpHttpsHandler()
    {
        Filters.Add(new Aspose.Html.Net.MessageFilters.ProtocolMessageFilter("http", "http"));
        Filters.Add(new Aspose.Html.Net.MessageFilters.ProtocolMessageFilter("https", "https"));
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new HttpHttpsHandler());

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com");
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                string title = document.Title;
                Console.WriteLine("Title: " + title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
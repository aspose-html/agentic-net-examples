// Use ProtocolMessageFilter to handle both "http" and "https" schemes for comprehensive coverage.

using System;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new ProtocolHandler());

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com");
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                Console.WriteLine("Document title: " + document.Title);
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

class ProtocolHandler : Aspose.Html.Net.MessageHandler
{
    public ProtocolHandler()
    {
        Filters.Add(new Aspose.Html.Net.MessageFilters.ProtocolMessageFilter("http", "https"));
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
    }
}
// Add a handler that strips query strings from URLs before they are passed to the network service.

using System;

class QueryStringStripHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        var uri = context.Request.RequestUri;
        string cleanUrl = uri.Protocol + "://" + uri.Host + uri.Pathname;
        context.Request.RequestUri = new Aspose.Html.Url(cleanUrl);
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new QueryStringStripHandler());

            using (var document = new Aspose.Html.HTMLDocument("https://example.com?param=123", configuration))
            {
                document.Save("output.html");
                Console.WriteLine("Document saved to output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
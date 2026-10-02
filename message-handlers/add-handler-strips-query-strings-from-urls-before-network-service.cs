// Add a handler that strips query strings from URLs before they are passed to the network service.

using System;

class Program
{
    static void Main()
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new QueryStringStripHandler());

            string htmlContent = "<html><body><a href=\"https://example.com/page?param=1\">Link</a></body></html>";
            using (var document = new Aspose.Html.HTMLDocument(htmlContent, new Aspose.Html.Url("about:blank"), configuration))
            {
                document.Save("output.html");
            }

            Console.WriteLine("Document processed and saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

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
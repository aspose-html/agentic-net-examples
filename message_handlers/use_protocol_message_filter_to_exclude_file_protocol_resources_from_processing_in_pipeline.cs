// Use ProtocolMessageFilter to exclude file protocol resources from processing in the pipeline.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Net.MessageFilters;
using Aspose.Html.Services;

class HttpOnlyHandler : Aspose.Html.Net.MessageHandler
{
    public HttpOnlyHandler()
    {
        Filters.Add(new ProtocolMessageFilter("http", "https"));
    }

    public override void Invoke(INetworkOperationContext context)
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
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new HttpOnlyHandler());

            RequestMessage request = new RequestMessage("https://example.com");
            using (HTMLDocument document = new HTMLDocument(request, configuration))
            {
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
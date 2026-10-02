// Insert a NetworkDisabledMessageHandler at the pipeline start to allow only the file protocol.

using System;

class NetworkDisabledMessageHandler : Aspose.Html.Net.MessageHandler
{
    public NetworkDisabledMessageHandler()
    {
        Filters.Add(new Aspose.Html.Net.MessageFilters.ProtocolMessageFilter("file"));
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a minimal local HTML file
            string htmlPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sample.html");
            System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");

            // Configure Aspose.HTML
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Insert the network disabled handler at the start of the pipeline
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Insert(0, new NetworkDisabledMessageHandler());

            // Load the document using a file URI
            string requestUri = new System.Uri(htmlPath).AbsoluteUri;
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(requestUri);
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                System.Console.WriteLine("Document loaded successfully. Title: " + document.Title);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
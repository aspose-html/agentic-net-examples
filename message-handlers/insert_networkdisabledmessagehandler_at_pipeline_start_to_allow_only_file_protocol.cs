// Insert a NetworkDisabledMessageHandler at the pipeline start to allow only the file protocol.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Net.MessageFilters;
using Aspose.Html.Services;

class FileProtocolHandler : Aspose.Html.Net.MessageHandler
{
    public FileProtocolHandler()
    {
        Filters.Add(new ProtocolMessageFilter("file"));
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
            string htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Insert(0, new FileProtocolHandler());

            string requestUri = "file:///" + htmlPath.Replace("\\", "/");
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(requestUri);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                Console.WriteLine("Document loaded successfully. Title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
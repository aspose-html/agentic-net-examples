// Insert a NetworkDisabledMessageHandler at the pipeline start to allow only the file protocol.

using System;
using System.IO;

class FileProtocolHandler : Aspose.Html.Net.MessageHandler
{
    public FileProtocolHandler()
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
            // Create a minimal HTML file
            string htmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            File.WriteAllText(htmlFilePath, "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");

            // Prepare configuration and network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new FileProtocolHandler());

            // Load the HTML document using file protocol
            string fileUri = new Uri(htmlFilePath).AbsoluteUri;
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(fileUri);
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Insert a NetworkDisabledMessageHandler at the pipeline start to allow only the file protocol.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Net.MessageHandlers;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and obtain the network service
            Configuration configuration = new Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();

            // Insert a handler that allows only the file protocol at the start of the pipeline
            networkService.MessageHandlers.Insert(0, new FileProtocolMessageHandler());

            // Load a local HTML document using the configured pipeline
            string htmlPath = "example.html";
            using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
            {
                // Perform any processing here (e.g., save a copy)
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
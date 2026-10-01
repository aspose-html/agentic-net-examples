// Use ProtocolMessageFilter to process only HTTP and HTTPS protocols in the pipeline.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Net.MessageFilters;
using Aspose.Html.Services;

class HttpHttpsHandler : Aspose.Html.Net.MessageHandler
{
    public HttpHttpsHandler()
    {
        Filters.Add(new Aspose.Html.Net.MessageFilters.ProtocolMessageFilter("http", "https"));
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
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service and add the custom handler
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new HttpHttpsHandler());

            // Create request message for an HTTPS URL
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com");

            // Load the document using the request and configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // Output the document title to console
                System.Console.WriteLine("Document Title: " + document.Title);

                // Save the document to a local file
                string outputPath = "output.html";
                document.Save(outputPath);
                System.Console.WriteLine("Document saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
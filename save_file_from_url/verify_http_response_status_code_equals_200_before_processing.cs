// Verify the HTTP response status code equals 200 before processing.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class StatusCheckHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        // Continue processing the request
        Next(context);
        // Abort if the response status is not 200 OK
        if (context.Response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            // Prevent further handling
            return;
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create Aspose.HTML configuration
            Configuration configuration = new Configuration();

            // Get the network service to register custom handlers
            INetworkService network = configuration.GetService<INetworkService>();

            // Add the status check handler to the pipeline
            network.MessageHandlers.Add(new StatusCheckHandler());

            // Load an HTML document with the configured pipeline
            using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
            {
                // Example processing: output the document title
                Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Verify the HTTP response status code equals 200 before processing.

using System;

class StatusCheckHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Perform the request
        Next(context);
        // Verify HTTP status code is 200 (OK)
        if (context.Response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception($"HTTP request failed with status code {(int)context.Response.StatusCode}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create Aspose.HTML configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Obtain the network service from the configuration
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add the custom status‑check handler
            network.MessageHandlers.Add(new StatusCheckHandler());

            // URL to load (replace with any reachable URL)
            string url = "https://example.com";

            // Load the HTML document using the configuration with the handler attached
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                // Example processing: output the document title
                Console.WriteLine("Title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
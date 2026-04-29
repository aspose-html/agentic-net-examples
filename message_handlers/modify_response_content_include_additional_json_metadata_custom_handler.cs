// Modify response content to include additional JSON metadata via a custom handler.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using System.Text.Json.Nodes;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and obtain network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<INetworkService>();

            // Register custom handler that adds metadata to JSON responses
            network.MessageHandlers.Add(new JsonMetadataHandler());

            // HTML content to load
            string htmlContent = "<html><body><h1>Hello</h1></body></html>";
            string baseUri = "http://example.com";
            string outputPath = "output.html";

            // Load document with custom configuration
            using (HTMLDocument document = new HTMLDocument(htmlContent, baseUri, configuration))
            {
                // Save the resulting document
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}

// Custom message handler that injects additional metadata into JSON responses
class JsonMetadataHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        // Continue processing the request/response pipeline
        Next(context);

        // Ensure there is content to read
        if (context.Response.Content == null) return;

        // Read response content as string
        string json = context.Response.Content.ReadAsString();

        try
        {
            // Parse JSON and add new property
            JsonNode node = JsonNode.Parse(json);
            node["extraMetadata"] = "added";

            // Output the modified JSON (could be logged or stored)
            string newJson = node.ToJsonString();
            Console.WriteLine(newJson);
        }
        catch
        {
            // Silently ignore parsing errors
        }
    }
}
// Validate JSON payload in request body using a custom validation handler.

using System;
using System.Text.Json.Nodes;
using Aspose.Html;
using Aspose.Html.Net;

class JsonValidationHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Continue processing the request/response pipeline
        Next(context);

        // Validate only if there is a response content
        if (context.Response.Content == null)
            return;

        string json = context.Response.Content.ReadAsString();

        try
        {
            JsonNode node = JsonNode.Parse(json);
            // Example validation: check for a required property
            if (node is JsonObject obj && !obj.ContainsKey("requiredField"))
            {
                Console.WriteLine("Validation error: 'requiredField' is missing in JSON payload.");
            }
            else
            {
                Console.WriteLine("JSON payload is valid.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid JSON format in response payload.");
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and attach the custom validation handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new JsonValidationHandler());

            // Load a sample HTML page that performs a network request (replace with a real URL if needed)
            string url = "https://example.com/api/data";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                // Save the resulting document to a file
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"Document saved to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
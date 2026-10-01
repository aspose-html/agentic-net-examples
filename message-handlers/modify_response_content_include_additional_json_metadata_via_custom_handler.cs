// Modify response content to include additional JSON metadata via a custom handler.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service and add custom handler
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new JsonModifierHandler());

            // Load a simple HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("", "", configuration);

            // Save the document
            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom message handler that modifies JSON responses
class JsonModifierHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if (context.Response.Content == null)
            return;

        string json = context.Response.Content.ReadAsString();
        try
        {
            System.Text.Json.Nodes.JsonNode node = System.Text.Json.Nodes.JsonNode.Parse(json);
            node["addedProperty"] = "newValue";
            string newJson = node.ToJsonString();
            Console.WriteLine(newJson);
        }
        catch
        {
            // Ignore parsing errors
        }
    }
}
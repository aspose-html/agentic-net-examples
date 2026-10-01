// Validate JSON payload in request body using a custom validation handler.

using System;
using System.Text.Json.Nodes;

class Program
{
    static void Main()
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new JsonValidationHandler());

            using (var document = new Aspose.Html.HTMLDocument("https://jsonplaceholder.typicode.com/posts/1", configuration))
            {
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

class JsonValidationHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if (context.Response.Content == null)
            return;

        string json = context.Response.Content.ReadAsString();
        try
        {
            JsonNode node = JsonNode.Parse(json);
            node["validated"] = true;
            string newJson = node.ToJsonString();
            Console.WriteLine(newJson);
        }
        catch
        {
            // Ignore parsing errors
        }
    }
}
// Validate JSON payload in request body using a custom validation handler.

using System;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new JsonValidationHandler());

            string html = "<!DOCTYPE html><html><body><script>fetch('https://jsonplaceholder.typicode.com/todos/1').then(r=>r.json()).then(d=>console.log(d));</script></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank", configuration))
            {
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Document saved to " + outputPath);
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
        if (context.Response.Content == null) return;

        string json = context.Response.Content.ReadAsString();
        try
        {
            System.Text.Json.Nodes.JsonNode node = System.Text.Json.Nodes.JsonNode.Parse(json);
            if (!node.AsObject().ContainsKey("userId"))
            {
                context.Response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                Console.WriteLine("JSON validation failed: missing 'userId'.");
            }
            else
            {
                node["validated"] = true;
                string newJson = node.ToJsonString();
                Console.WriteLine("Validated JSON: " + newJson);
            }
        }
        catch
        {
            // Not a JSON response; ignore.
        }
    }
}
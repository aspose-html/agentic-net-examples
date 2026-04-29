// Validate JSON payload in request body using a custom validation handler.

using System;
using System.Net;
using System.Text.Json.Nodes;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class JsonRequestValidationHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        if (context.Request.Content != null)
        {
            string json = context.Request.Content.ReadAsString();
            try
            {
                JsonNode node = JsonNode.Parse(json);
                if (node["requiredField"] == null)
                {
                    context.Response.StatusCode = HttpStatusCode.BadRequest;
                    return;
                }
            }
            catch
            {
                context.Response.StatusCode = HttpStatusCode.BadRequest;
                return;
            }
        }
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new JsonRequestValidationHandler());

            using HTMLDocument document = new HTMLDocument("https://example.com", configuration);
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
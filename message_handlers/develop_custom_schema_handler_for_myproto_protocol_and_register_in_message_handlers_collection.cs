// Develop a custom schema handler for the myproto protocol and register it in the message handlers collection.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CustomSchemaMessageFilter : MessageFilter
{
    private readonly string _schema;
    public CustomSchemaMessageFilter(string schema)
    {
        _schema = schema;
    }
    public override bool Match(INetworkOperationContext context)
    {
        // Compare the request protocol with the stored schema (case‑insensitive)
        return string.Equals(_schema, context.Request.RequestUri.Protocol.TrimEnd(':'), StringComparison.OrdinalIgnoreCase);
    }
}

abstract class CustomSchemaMessageHandler : MessageHandler
{
    protected CustomSchemaMessageHandler(string schema)
    {
        // Register the custom filter for the specified schema
        Filters.Add(new CustomSchemaMessageFilter(schema));
    }
}

class MyProtoMessageHandler : CustomSchemaMessageHandler
{
    public MyProtoMessageHandler() : base("myproto")
    {
    }
    public override void Invoke(INetworkOperationContext context)
    {
        // Custom processing can be added here
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and obtain the network service
            var configuration = new Configuration();
            var network = configuration.GetService<INetworkService>();

            // Register the custom handler for the "myproto" scheme
            network.MessageHandlers.Add(new MyProtoMessageHandler());

            // Load a document using a request with the custom protocol
            var request = new RequestMessage("myproto://example");
            using (var document = new HTMLDocument(request, configuration))
            {
                Console.WriteLine("Document loaded with custom schema handler.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
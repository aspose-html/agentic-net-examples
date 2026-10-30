// Develop a custom schema handler for the myproto protocol and register it in the message handlers collection.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Register custom handler for "myproto" protocol
            network.MessageHandlers.Add(new MyProtoHandler());

            // Create a request using the custom protocol
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("myproto://example");

            // Load the document (will trigger the custom handler)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                System.Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom filter that matches a specific protocol schema
public class CustomSchemaMessageFilter : Aspose.Html.Net.MessageFilter
{
    private readonly string _schema;
    public CustomSchemaMessageFilter(string schema)
    {
        this._schema = schema;
    }

    public override bool Match(Aspose.Html.Net.INetworkOperationContext context)
    {
        return string.Equals(_schema, context.Request.RequestUri.Protocol.TrimEnd(':'), System.StringComparison.OrdinalIgnoreCase);
    }
}

// Abstract handler that adds the custom schema filter
public abstract class CustomSchemaMessageHandler : Aspose.Html.Net.MessageHandler
{
    protected CustomSchemaMessageHandler(string schema)
    {
        this.Filters.Add(new CustomSchemaMessageFilter(schema));
    }
}

// Concrete handler for the "myproto" protocol
public sealed class MyProtoHandler : CustomSchemaMessageHandler
{
    public MyProtoHandler() : base("myproto") { }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Add a custom header to the request
        context.Request.Headers["X-MyProto-Id"] = System.Guid.NewGuid().ToString();
        Next(context);
    }
}
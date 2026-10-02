// Develop a custom schema handler for the myproto protocol and register it in the message handlers collection.

using System;

public class CustomSchemaMessageFilter : Aspose.Html.Net.MessageFilter
{
    private readonly string schema;
    public CustomSchemaMessageFilter(string schema)
    {
        this.schema = schema;
    }

    public override bool Match(Aspose.Html.Net.INetworkOperationContext context)
    {
        return string.Equals(schema, context.Request.RequestUri.Protocol.TrimEnd(':'), StringComparison.OrdinalIgnoreCase);
    }
}

public abstract class CustomSchemaMessageHandler : Aspose.Html.Net.MessageHandler
{
    protected CustomSchemaMessageHandler(string schema)
    {
        Filters.Add(new CustomSchemaMessageFilter(schema));
    }
}

public class MyProtoMessageHandler : CustomSchemaMessageHandler
{
    public MyProtoMessageHandler() : base("myproto")
    {
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Headers["X-MyProto-Id"] = Guid.NewGuid().ToString();
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new MyProtoMessageHandler());

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("myproto://example");
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
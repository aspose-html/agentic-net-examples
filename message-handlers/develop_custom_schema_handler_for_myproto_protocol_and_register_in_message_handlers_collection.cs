// Develop a custom schema handler for the myproto protocol and register it in the message handlers collection.

using System;

namespace CustomSchemaHandlerExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                var configuration = new Aspose.Html.Configuration();
                var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                network.MessageHandlers.Add(new MyProtoMessageHandler());

                using (var document = new Aspose.Html.HTMLDocument("myproto://example", configuration))
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

    class MyProtoMessageHandler : Aspose.Html.Net.MessageHandler
    {
        public MyProtoMessageHandler()
        {
            Filters.Add(new Aspose.Html.Net.MessageFilters.ProtocolMessageFilter("myproto", "myproto"));
        }

        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            context.Request.Headers["X-MyProto-Header"] = Guid.NewGuid().ToString();
            Next(context);
        }
    }
}
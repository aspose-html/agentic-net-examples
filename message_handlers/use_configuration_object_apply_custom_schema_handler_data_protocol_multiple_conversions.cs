// Use the Configuration object to apply a custom schema handler for the data protocol across multiple conversions.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class CustomSchemaMessageFilter : MessageFilter
{
    private readonly string _schema;
    public CustomSchemaMessageFilter(string schema) { _schema = schema; }
    public override bool Match(INetworkOperationContext context)
    {
        return string.Equals(_schema, context.Request.RequestUri.Protocol.TrimEnd(':'), StringComparison.OrdinalIgnoreCase);
    }
}

class DataProtocolMessageHandler : MessageHandler
{
    public DataProtocolMessageHandler()
    {
        Filters.Add(new CustomSchemaMessageFilter("data"));
    }
    public override void Invoke(INetworkOperationContext context)
    {
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            var configuration = new Configuration();
            var network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new DataProtocolMessageHandler());

            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            using (var document = new HTMLDocument(htmlContent, "http://example.com/", configuration))
            {
                var options = new PdfSaveOptions();
                Converter.ConvertHTML(document, options, "output.pdf");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
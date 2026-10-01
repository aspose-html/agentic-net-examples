// Use the Configuration object to apply a custom schema handler for the data protocol across multiple conversions.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class CustomSchemaMessageFilter : Aspose.Html.Net.MessageFilter
{
    private readonly string _schema;
    public CustomSchemaMessageFilter(string schema) { _schema = schema; }
    public override bool Match(Aspose.Html.Net.INetworkOperationContext context)
    {
        return string.Equals(_schema, context.Request.RequestUri.Protocol.TrimEnd(':'), StringComparison.OrdinalIgnoreCase);
    }
}

abstract class CustomSchemaMessageHandler : Aspose.Html.Net.MessageHandler
{
    protected CustomSchemaMessageHandler(string schema)
    {
        Filters.Add(new CustomSchemaMessageFilter(schema));
    }
}

class DataProtocolHandler : CustomSchemaMessageHandler
{
    public DataProtocolHandler() : base("data") { }
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Headers["X-Custom-Header"] = System.Guid.NewGuid().ToString();
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and add custom handler for data protocol
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new DataProtocolHandler());

            // Prepare a data URI containing simple HTML
            string htmlContent = "<html><head><title>Test Document</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string dataUri = "data:text/html," + Uri.EscapeDataString(htmlContent);
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(dataUri);

            // Load document using the configuration with custom handler
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // Convert to PDF
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                string pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
                Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, pdfPath);
                Console.WriteLine("PDF saved to: " + pdfPath);

                // Convert to MHTML
                Aspose.Html.Saving.MHTMLSaveOptions mhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();
                string mhtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "output.mhtml");
                Aspose.Html.Converters.Converter.ConvertHTML(document, mhtmlOptions, mhtmlPath);
                Console.WriteLine("MHTML saved to: " + mhtmlPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
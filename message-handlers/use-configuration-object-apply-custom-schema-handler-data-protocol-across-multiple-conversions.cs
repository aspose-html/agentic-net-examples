// Use the Configuration object to apply a custom schema handler for the data protocol across multiple conversions.

using System;
using System.IO;

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
        context.Request.Headers["X-Custom-Data-Handler"] = Guid.NewGuid().ToString();
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file with a data URI image
            string htmlContent = @"<!DOCTYPE html><html><body><h1>Data URI Test</h1><img src=""data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XK6cAAAAASUVORK5CYII="" alt=""pixel""/></body></html>";
            string inputPath = "sample.html";
            File.WriteAllText(inputPath, htmlContent);

            // Create configuration and add custom data protocol handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new DataProtocolHandler());

            // Load HTML document using the configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration))
            {
                // Convert to PDF
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                string pdfPath = "output.pdf";
                Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, pdfPath);

                // Convert to MHTML
                Aspose.Html.Saving.MHTMLSaveOptions mhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();
                string mhtmlPath = "output.mhtml";
                Aspose.Html.Converters.Converter.ConvertHTML(document, mhtmlOptions, mhtmlPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
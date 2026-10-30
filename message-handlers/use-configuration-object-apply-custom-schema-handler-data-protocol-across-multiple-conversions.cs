// Use the Configuration object to apply a custom schema handler for the data protocol across multiple conversions.

using System;
using Aspose.Html.Net;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

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
        context.Request.Headers["X-Data-Protocol"] = Guid.NewGuid().ToString();
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and register custom schema handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new DataProtocolHandler());

            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Load document with custom configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", configuration))
            {
                // Convert to PDF
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                string pdfPath = "output.pdf";
                Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, pdfPath);
                Console.WriteLine($"PDF saved to: {pdfPath}");

                // Convert to PNG image
                Aspose.Html.Saving.ImageSaveOptions imgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
                string pngPath = "output.png";
                Aspose.Html.Converters.Converter.ConvertHTML(document, imgOptions, pngPath);
                Console.WriteLine($"PNG saved to: {pngPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Add a custom header indicating conversion version to response using a version‑header handler.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Saving;

class VersionHeaderHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        context.Response.Headers["X-Conversion-Version"] = "1.0";
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and register the response header handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new VersionHeaderHandler());

            // Load an HTML document using the configured network service
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", "", configuration))
            {
                // Set PDF conversion options
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                // Convert HTML to PDF; the custom response header will be added during the process
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.pdf");
            }

            Console.WriteLine("Conversion completed. PDF saved as output.pdf");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
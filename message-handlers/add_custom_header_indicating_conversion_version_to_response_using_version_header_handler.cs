// Add a custom header indicating conversion version to response using a version‑header handler.

using System;

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
    static void Main(string[] args)
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Add custom header handler
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new VersionHeaderHandler());

            // Sample HTML content
            string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";

            // Load document with configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("about:blank", html, configuration))
            {
                // Convert to PDF
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.pdf");
            }

            Console.WriteLine("Conversion completed. PDF saved at output.pdf");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
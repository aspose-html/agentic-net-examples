// Configure custom HttpClient headers, such as a User‑Agent string, before downloading resources.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service and add custom header handler
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new UserAgentHandler());

            // URL to download
            string url = "https://example.com";

            // Load HTML document with custom configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, url, configuration))
            {
                // Set PDF save options
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                // Output file path
                string outputPath = "output.pdf";

                // Convert HTML to PDF
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom message handler to set User-Agent header
class UserAgentHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Headers["User-Agent"] = "MyCustomUserAgent/1.0";
        Next(context);
    }
}
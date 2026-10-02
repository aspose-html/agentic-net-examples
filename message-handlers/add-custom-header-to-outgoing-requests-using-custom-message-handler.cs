// Add a custom header to outgoing requests using a custom message handler.

using System;

class CustomHeaderHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Headers["X-Custom-Header"] = "MyValue";
        base.Next(context);
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create configuration and add custom message handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CustomHeaderHandler());

            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";

            // Load document with configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", configuration))
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
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
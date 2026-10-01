// Add a correlation ID header to each request using a custom message handler.

using System;
using System.IO;

class CorrelationIdHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Headers["X-Correlation-ID"] = Guid.NewGuid().ToString();
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and add custom message handler
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CorrelationIdHandler());

            // Prepare a minimal HTML file
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample Document</title></head><body><h1>Hello, World!</h1></body></html>";
            string tempFilePath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFilePath, htmlContent);

            // Load the document using the configuration with the handler
            using (var document = new Aspose.Html.HTMLDocument(tempFilePath, configuration))
            {
                Console.WriteLine("Document title: " + document.Title);
            }

            // Clean up temporary file
            if (File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
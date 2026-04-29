// Abort pipeline if response status code is 500 using an error‑short‑circuit handler.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

namespace AbortOn500Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a configuration instance
                Configuration configuration = new Configuration();

                // Retrieve the network service from the configuration
                INetworkService network = configuration.GetService<INetworkService>();

                // Register the custom handler that aborts processing on HTTP 500 responses
                network.MessageHandlers.Add(new Http500AbortHandler());

                // Sample HTML content to load
                string htmlContent = "<html><body><h1>Hello World</h1></body></html>";

                // Load the HTML document using the configuration with the handler attached
                using (HTMLDocument document = new HTMLDocument(htmlContent, configuration))
                {
                    // Document is now loaded; further processing can be performed here
                    Console.WriteLine("Document loaded successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Custom message handler that short‑circuits the pipeline when a 500 status code is encountered
        class Http500AbortHandler : MessageHandler
        {
            public override void Invoke(INetworkOperationContext context)
            {
                // Invoke the next handler in the pipeline first
                Next(context);

                // If the response status is 500 (Internal Server Error), abort further processing
                if (context.Response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    // Returning without further action stops the pipeline for this request
                    return;
                }
            }
        }
    }
}
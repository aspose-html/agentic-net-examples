// Throttle network requests to avoid overwhelming the target server during large‑scale website conversion.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using System.Threading;

namespace ThrottleExample
{
    // Custom message handler that introduces a short delay before each request
    public sealed class ThrottleHandler : MessageHandler
    {
        public override void Invoke(INetworkOperationContext context)
        {
            // Simple throttle: wait 200 milliseconds before proceeding
            Thread.Sleep(200);
            // Continue processing the request
            Next(context);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Target website URL and output file path
                string url = "https://example.com";
                string outputPath = "output.html";

                // Create a configuration instance
                Configuration configuration = new Configuration();

                // Obtain the network service from the configuration
                INetworkService networkService = configuration.GetService<INetworkService>();

                // Register the custom throttle handler
                networkService.MessageHandlers.Add(new ThrottleHandler());

                // Load the website using the configuration with throttling applied
                using (HTMLDocument document = new HTMLDocument(url, configuration))
                {
                    // Prepare save options with resource handling restrictions
                    HTMLSaveOptions options = new HTMLSaveOptions();
                    options.ResourceHandlingOptions.MaxHandlingDepth = 1;
                    options.ResourceHandlingOptions.PageUrlRestriction = UrlRestriction.SameHost;

                    // Save the converted HTML to the local file system
                    document.Save(outputPath, options);
                }

                Console.WriteLine("Website conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
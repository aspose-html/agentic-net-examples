// Create a Configuration, add a one‑second TimeoutMessageHandler, and load an HTML file.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class OneSecondTimeoutMessageHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        // Set request timeout to 1 second
        context.Request.Timeout = TimeSpan.FromSeconds(1);
        // Continue to the next handler in the chain
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Create a configuration instance
            var configuration = new Configuration();

            // Retrieve the network service from the configuration
            var networkService = configuration.GetService<INetworkService>();

            // Add the custom one‑second timeout handler
            networkService.MessageHandlers.Add(new OneSecondTimeoutMessageHandler());

            // Path to the HTML file to load
            string htmlPath = "sample.html";

            // Load the HTML document using the configured timeout handler
            using (var document = new HTMLDocument(htmlPath, configuration))
            {
                Console.WriteLine("HTML document loaded successfully.");
                // Additional processing can be done here
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
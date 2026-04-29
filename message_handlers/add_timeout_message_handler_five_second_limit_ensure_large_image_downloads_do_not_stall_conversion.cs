// Add a TimeoutMessageHandler with a five‑second limit to ensure large image downloads do not stall conversion.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Services;

namespace HtmlConversionWithTimeout
{
    // Custom message handler that sets a 5‑second timeout for each network request.
    public sealed class TimeoutMessageHandler : MessageHandler
    {
        public override void Invoke(INetworkOperationContext context)
        {
            context.Request.Timeout = TimeSpan.FromSeconds(5);
            Next(context);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the source HTML file and the output image.
            string htmlPath = "input.html";
            string outputPath = "output.png";

            try
            {
                // Create a configuration instance.
                Configuration configuration = new Configuration();

                // Obtain the network service from the configuration.
                INetworkService networkService = configuration.GetService<INetworkService>();

                // Register the timeout handler.
                networkService.MessageHandlers.Add(new TimeoutMessageHandler());

                // Load the HTML document using the configuration.
                using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
                {
                    // Convert the document to an image.
                    Converter.ConvertHTML(document, new ImageSaveOptions(), outputPath);
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
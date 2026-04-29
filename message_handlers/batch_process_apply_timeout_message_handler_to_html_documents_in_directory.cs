// Create a batch process that applies TimeoutMessageHandler to each HTML document in a directory.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Net;
using Aspose.Html.Services;

class TimeoutMessageHandler : MessageHandler
{
    // Sets a 5‑second timeout for each network request during document loading
    public override void Invoke(INetworkOperationContext context)
    {
        context.Request.Timeout = TimeSpan.FromSeconds(5);
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Directory containing HTML files
            string inputDir = "input";

            // Process each HTML file in the directory
            foreach (string htmlPath in Directory.GetFiles(inputDir, "*.html"))
            {
                // Create a configuration and register the timeout handler
                Configuration configuration = new Configuration();
                INetworkService networkService = configuration.GetService<INetworkService>();
                networkService.MessageHandlers.Add(new TimeoutMessageHandler());

                // Load the HTML document with the configured timeout behavior
                using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
                {
                    // Define output image path (same name with .png extension)
                    string outputPath = Path.ChangeExtension(htmlPath, ".png");

                    // Convert the document to an image
                    ImageSaveOptions options = new ImageSaveOptions();
                    Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
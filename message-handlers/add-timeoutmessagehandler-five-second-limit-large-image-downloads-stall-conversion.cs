// Add a TimeoutMessageHandler with a five‑second limit to ensure large image downloads do not stall conversion.

using System;

public sealed class TimeoutMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = System.TimeSpan.FromSeconds(5);
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Add timeout handler
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new TimeoutMessageHandler());

            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1><img src='https://example.com/large-image.jpg' /></body></html>";

            // Load document with base URI
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", configuration))
            {
                // Set image save options
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                options.Format = Aspose.Html.Rendering.Image.ImageFormat.Png;

                // Output file path
                string outputPath = "output.png";

                // Perform conversion
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
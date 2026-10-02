// Add retry logic for transient network failures when downloading images or icons.

using System;
using System.IO;
using Aspose.Html.Net;

public sealed class RetryHandler : Aspose.Html.Net.MessageHandler
{
    private readonly int _maxRetries;
    public RetryHandler(int maxRetries)
    {
        _maxRetries = maxRetries;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        for (int attempt = 0; attempt <= _maxRetries; attempt++)
        {
            Next(context);
            if (context.Response != null && (int)context.Response.StatusCode < 500)
            {
                break;
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Input HTML URL (can be any reachable page with images/icons)
            string inputUrl = "https://example.com/sample.html";
            // Output image file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");

            // Configure Aspose.HTML with retry handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new RetryHandler(3));

            // Load the HTML document from the URL using the configured network service
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputUrl, configuration))
            {
                // Convert the HTML document to an image (PNG)
                Aspose.Html.Saving.ImageSaveOptions saveOptions = new Aspose.Html.Saving.ImageSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, saveOptions, outputPath);
            }

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
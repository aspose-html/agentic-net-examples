// Configure a TimeoutMessageHandler with a dynamic timeout value based on the size of the requested resource.

using System;

public sealed class TimeoutMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Set a fixed timeout of 5 seconds
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
            // Create configuration and register the custom timeout handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new TimeoutMessageHandler());

            // Define the URL to load
            string url = "https://example.com/largefile.html";

            // Load the HTML document using the configured network service
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration);

            // Convert the loaded document to PDF
            string outputPath = "output.pdf";
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
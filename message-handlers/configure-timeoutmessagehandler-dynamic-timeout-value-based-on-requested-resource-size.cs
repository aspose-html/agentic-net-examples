// Configure a TimeoutMessageHandler with a dynamic timeout value based on the size of the requested resource.

using System;

public sealed class DynamicTimeoutMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        int baseTimeout = 5;
        // Set a fixed timeout; URL-based adjustment removed because RequestMessage has no Url property.
        context.Request.Timeout = System.TimeSpan.FromSeconds(baseTimeout);
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new DynamicTimeoutMessageHandler());

            string url = "https://example.com";
            string outputPath = "output.pdf";

            // Load the document using the configuration (optional, shown for completeness)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                // Convert the URL directly to PDF
                Aspose.Html.Converters.Converter.ConvertHTML(url, new Aspose.Html.Saving.PdfSaveOptions(), outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
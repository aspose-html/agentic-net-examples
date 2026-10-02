// Set a global three‑second timeout for all network requests during PDF conversion.

public sealed class TimeoutMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = System.TimeSpan.FromSeconds(3);
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Define directories
            string dataDir = "Data";
            string outputDir = "Output";

            // Ensure directories exist
            System.IO.Directory.CreateDirectory(dataDir);
            System.IO.Directory.CreateDirectory(outputDir);

            // Create a minimal HTML file if it does not exist
            string documentPath = System.IO.Path.Combine(dataDir, "document.html");
            if (!System.IO.File.Exists(documentPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                System.IO.File.WriteAllText(documentPath, htmlContent);
            }

            // Prepare output path
            string savePath = System.IO.Path.Combine(outputDir, "document.pdf");

            // Create configuration and set global timeout handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new TimeoutMessageHandler());

            // Convert HTML to PDF with the configured timeout
            Aspose.Html.Converters.Converter.ConvertHTML(documentPath, configuration, new Aspose.Html.Saving.PdfSaveOptions(), savePath);

            System.Console.WriteLine("PDF conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
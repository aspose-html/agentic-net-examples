// Set a global three‑second timeout for all network requests during PDF conversion.

using System;
using System.IO;

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
            // Prepare input HTML file
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);
            string documentPath = Path.Combine(dataDir, "document.html");
            if (!File.Exists(documentPath))
            {
                File.WriteAllText(documentPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            string savePath = Path.Combine(outputDir, "document.pdf");

            // Configure global network timeout
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new TimeoutMessageHandler());

            // Convert HTML to PDF with the configured timeout
            Aspose.Html.Converters.Converter.ConvertHTML(
                documentPath,
                configuration,
                new Aspose.Html.Saving.PdfSaveOptions(),
                savePath
            );

            Console.WriteLine("PDF conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
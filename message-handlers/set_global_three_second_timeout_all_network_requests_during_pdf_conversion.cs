// Set a global three‑second timeout for all network requests during PDF conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;

public sealed class TimeoutMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = TimeSpan.FromSeconds(3);
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string dataDir = "Data";
            string outputDir = "Output";

            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string htmlPath = Path.Combine(dataDir, "sample.html");
            string pdfPath = Path.Combine(outputDir, "sample.pdf");

            // Create a minimal HTML file
            File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");

            // Configure global network timeout
            var configuration = new Aspose.Html.Configuration();
            var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new TimeoutMessageHandler());

            // Convert HTML to PDF with the configured timeout
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, configuration, new Aspose.Html.Saving.PdfSaveOptions(), pdfPath);

            Console.WriteLine("PDF successfully saved to: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
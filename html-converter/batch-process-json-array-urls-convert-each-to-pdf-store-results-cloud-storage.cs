// Batch process a JSON array of URLs, converting each to PDF and storing results in cloud storage.

using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Rendering.Pdf;

public sealed class TimeoutHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = System.TimeSpan.FromSeconds(30);
        Next(context);
    }
}

public class Program
{
    public static Aspose.Html.Configuration CreateConfiguration()
    {
        Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
        Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
        networkService.MessageHandlers.Add(new TimeoutHandler());
        return configuration;
    }

    public static void Main(string[] args)
    {
        try
        {
            // Sample JSON array of URLs
            string json = "[\"https://example.com\",\"https://example.org\"]";

            // Parse JSON
            List<string> urls = new List<string>();
            using (JsonDocument doc = JsonDocument.Parse(json))
            {
                foreach (JsonElement element in doc.RootElement.EnumerateArray())
                {
                    if (element.ValueKind == JsonValueKind.String)
                    {
                        urls.Add(element.GetString());
                    }
                }
            }

            // Simulated cloud storage folder
            string cloudFolder = Path.Combine(Directory.GetCurrentDirectory(), "CloudStorage");
            Directory.CreateDirectory(cloudFolder);

            foreach (string url in urls)
            {
                // Create configuration with timeout handler
                Aspose.Html.Configuration configuration = CreateConfiguration();

                // Generate a safe file name for the PDF
                string fileName = Guid.NewGuid().ToString() + ".pdf";
                string outputPdfPath = Path.Combine(cloudFolder, fileName);

                // Load HTML from URL and render to PDF
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine($"Converted '{url}' to PDF at '{outputPdfPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
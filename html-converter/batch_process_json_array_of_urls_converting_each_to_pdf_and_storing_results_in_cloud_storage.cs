// Batch process a JSON array of URLs, converting each to PDF and storing results in cloud storage.

using System;
using System.IO;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Net;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample JSON array of URLs
            string json = "[\"https://example.com\",\"https://example.org\"]";
            string[] urls = JsonSerializer.Deserialize<string[]>(json);

            // Local folder simulating cloud storage
            string cloudStoragePath = Path.Combine(Path.GetTempPath(), "AsposeHtmlCloudStorage");
            Directory.CreateDirectory(cloudStoragePath);

            foreach (string url in urls)
            {
                // Create configuration with timeout handler
                Configuration configuration = CreateConfiguration();

                // Determine output PDF file name
                string fileName = Path.GetFileNameWithoutExtension(new Uri(url).AbsolutePath);
                if (string.IsNullOrEmpty(fileName))
                {
                    fileName = "document";
                }
                string pdfFileName = fileName + ".pdf";
                string localPdfPath = Path.Combine(Path.GetTempPath(), pdfFileName);

                // Load HTML document from URL and convert to PDF
                using (HTMLDocument document = new HTMLDocument(url, configuration))
                {
                    PdfSaveOptions options = new PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, localPdfPath);
                }

                // Simulate uploading to cloud storage by copying the file
                string cloudPdfPath = Path.Combine(cloudStoragePath, pdfFileName);
                File.Copy(localPdfPath, cloudPdfPath, true);

                Console.WriteLine($"Converted and stored PDF for URL: {url}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static Configuration CreateConfiguration()
    {
        Configuration configuration = new Configuration();
        INetworkService networkService = configuration.GetService<INetworkService>();
        networkService.MessageHandlers.Add(new TimeoutHandler());
        return configuration;
    }
}

public sealed class TimeoutHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        context.Request.Timeout = TimeSpan.FromSeconds(30);
        Next(context);
    }
}
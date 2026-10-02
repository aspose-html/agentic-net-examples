// Provide a progress callback delegate to report percentage completed during download.

using System;
using System.Diagnostics;
using Aspose.Html.Net;

public sealed class ProgressMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly Action<int> _progressCallback;

    public ProgressMessageHandler(Action<int> progressCallback)
    {
        _progressCallback = progressCallback ?? throw new ArgumentNullException(nameof(progressCallback));
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Report start of download (0%)
        _progressCallback(0);
        // Continue with the request
        Next(context);
        // Report completion of download (100%)
        _progressCallback(100);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Define input URL and output PDF path
            string url = "https://example.com";
            string outputPdfPath = "output.pdf";

            // Create configuration and attach progress handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new ProgressMessageHandler(percent =>
            {
                Console.WriteLine($"Download progress: {percent}%");
            }));

            // Load HTML document from the URL
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            // Render to PDF
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
            {
                Stopwatch conversionTimer = Stopwatch.StartNew();
                document.RenderTo(device);
                conversionTimer.Stop();
                Console.WriteLine($"Conversion completed in {conversionTimer.Elapsed.TotalSeconds:F2} seconds.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
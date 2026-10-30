// Skip downloading icons larger than a specified byte size threshold to conserve bandwidth.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

public sealed class IconSizeFilterHandler : Aspose.Html.Net.MessageHandler
{
    private const long SizeThreshold = 5000; // bytes

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri != null ? context.Request.RequestUri.ToString() : string.Empty;
        if (!string.IsNullOrEmpty(requestUri) &&
            (requestUri.EndsWith(".ico", System.StringComparison.OrdinalIgnoreCase) ||
             requestUri.EndsWith(".png", System.StringComparison.OrdinalIgnoreCase) ||
             requestUri.EndsWith(".jpg", System.StringComparison.OrdinalIgnoreCase) ||
             requestUri.EndsWith(".jpeg", System.StringComparison.OrdinalIgnoreCase)))
        {
            // Skip downloading the icon to conserve bandwidth.
            System.Console.WriteLine($"Skipping download of icon: {requestUri}");
            // Do not invoke the next handler, effectively preventing the download.
            return;
        }

        // Proceed with normal processing for other resources.
        Next(context);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Define input HTML and output PDF paths.
            string inputHtmlPath = "sample.html";
            string outputPdfPath = "output.pdf";

            // Create a minimal sample HTML file with icons.
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head><title>Icon Skip Example</title></head>
<body>
    <h1>Test Page</h1>
    <img src=""https://example.com/small-icon.png"" alt=""Small Icon"" />
    <img src=""https://example.com/large-icon.png"" alt=""Large Icon"" />
    <p>This page demonstrates skipping icon downloads.</p>
</body>
</html>";
            System.IO.File.WriteAllText(inputHtmlPath, htmlContent);

            // Configure Aspose.HTML with the custom message handler.
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new IconSizeFilterHandler());

            // Load the HTML document using the configuration.
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath, configuration))
            {
                // Convert the HTML document to PDF.
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPdfPath);
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
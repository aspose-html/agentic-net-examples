// Exclude specific URL patterns from conversion using regular‑expression filters during processing.

using System;
using System.Text.RegularExpressions;

class ExcludeUrlMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly Regex _excludeRegex = new Regex(@"^https?://.*\.png$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string urlText = context.Request.RequestUri.ToString();
        if (_excludeRegex.IsMatch(urlText))
        {
            return;
        }
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and customize network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new ExcludeUrlMessageHandler());

            // Prepare request (using a simple HTML string via data URI)
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string dataUri = "data:text/html;charset=utf-8," + Uri.EscapeDataString(htmlContent);
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(dataUri);

            // Load document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // Set MHTML save options (default options are sufficient)
                Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();

                // Define output path
                string outputPath = "output.mhtml";

                // Convert HTML document to MHTML file
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                Console.WriteLine($"Conversion completed. Output saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
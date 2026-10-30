// Exclude specific URL patterns from conversion using regular‑expression filters during processing.

using System;
using System.Text.RegularExpressions;
using Aspose.Html.Net;

class ExcludeUrlHandler : Aspose.Html.Net.MessageHandler
{
    private readonly Regex _excludeRegex = new Regex(@"^https?://.*\.example\.com/skip/", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string url = context.Request.RequestUri.ToString();
        if (_excludeRegex.IsMatch(url))
        {
            // Skip processing this request
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
            // Configuration and network service setup
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new ExcludeUrlHandler());

            // Request to be converted
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com");

            // Load the document using the request and configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // Conversion options
                Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();

                // Output path
                string outputPath = "output.mhtml";

                // Perform conversion
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
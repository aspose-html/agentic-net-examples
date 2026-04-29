// Exclude specific URL patterns from conversion using regular‑expression filters during processing.

using System;
using System.Text.RegularExpressions;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Saving;

class ExcludeUrlHandler : Aspose.Html.Net.MessageHandler
{
    private readonly Regex _excludeRegex = new Regex(".*\\.png$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string url = context.Request.RequestUri.ToString();
        if (_excludeRegex.IsMatch(url))
        {
            // Skip loading resources that match the pattern
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
            // Create configuration and register the custom handler
            var configuration = new Aspose.Html.Configuration();
            var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new ExcludeUrlHandler());

            // Load the HTML document from a URL using the configured pipeline
            var request = new Aspose.Html.Net.RequestMessage("https://example.com/page.html");
            using (var document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // Set conversion options and output path
                var options = new Aspose.Html.Saving.MHTMLSaveOptions();
                string outputPath = "output.mhtml";

                // Convert HTML to MHTML
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
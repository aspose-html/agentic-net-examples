// Exclude specific URL patterns from conversion using regular‑expression filters during processing.

using System;
using System.Text.RegularExpressions;
using Aspose.Html.Net;

class ExcludeUrlHandler : Aspose.Html.Net.MessageHandler
{
    private readonly Regex _excludeRegex = new Regex(@"https?://.*\.png", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string url = context.Request.RequestUri.ToString();
        if (_excludeRegex.IsMatch(url))
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
            // Create configuration and add custom message handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new ExcludeUrlHandler());

            // Define the request URL
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com");

            // Load the HTML document using the request and configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // Set up MHTML save options
                Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();

                // Define output path
                string outputPath = "output.mhtml";

                // Convert HTML to MHTML
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
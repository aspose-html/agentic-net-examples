// Throttle network requests to avoid overwhelming the target server during large‑scale website conversion.

using System;

class ExcludeUrlHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Text.RegularExpressions.Regex _excludeRegex =
        new System.Text.RegularExpressions.Regex(@"^https?://.*\.png$", System.Text.RegularExpressions.RegexOptions.Compiled | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

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

class TimeoutHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = System.TimeSpan.FromSeconds(5);
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and obtain network service
            var configuration = new Aspose.Html.Configuration();
            var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add custom message handlers
            networkService.MessageHandlers.Add(new ExcludeUrlHandler());
            networkService.MessageHandlers.Add(new TimeoutHandler());

            // Sample HTML content
            string htmlContent = "<html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Load document using the configuration
            using (var document = new Aspose.Html.HTMLDocument(htmlContent, configuration))
            {
                // Set up MHTML save options
                var options = new Aspose.Html.Saving.MHTMLSaveOptions();

                // Output file path
                string outputPath = "output.mhtml";

                // Convert and save
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine($"MHTML file saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
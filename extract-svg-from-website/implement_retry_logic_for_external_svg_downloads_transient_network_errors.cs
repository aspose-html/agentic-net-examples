// Implement retry logic for external SVG downloads that fail due to transient network errors.

using System;
using System.IO;

class RetryMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly int _maxRetries;
    public RetryMessageHandler(int maxRetries) { _maxRetries = maxRetries; }
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        for (int attempt = 0; attempt <= _maxRetries; attempt++)
        {
            Next(context);
            if ((int)context.Response.StatusCode < 500) break;
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='lightblue'/><circle cx='100' cy='100' r='80' stroke='green' stroke-width='4' fill='yellow' /></svg>";
            string baseUri = "https://example.com/";
            string outputPath = "output.pdf";

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new RetryMessageHandler(3));

            // Perform conversion (the retry handler will be applied to any network operations during conversion)
            Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
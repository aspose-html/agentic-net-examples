// Implement retry logic for external SVG downloads that fail due to transient network errors.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string svgContent = "<svg width=\"100\" height=\"100\" xmlns=\"http://www.w3.org/2000/svg\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"black\" stroke-width=\"2\" fill=\"red\" /></svg>";
            string baseUri = "about:blank";
            string outputPath = "output.pdf";

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new RetryHandler(3));

            // Perform the conversion; the retry handler will intercept network operations.
            Aspose.Html.Converters.Converter.ConvertSVG(svgContent, baseUri, options, outputPath);

            Console.WriteLine("SVG successfully converted to PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}

class RetryHandler : Aspose.Html.Net.MessageHandler
{
    private readonly int _maxRetries;

    public RetryHandler(int maxRetries)
    {
        _maxRetries = maxRetries;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        for (int attempt = 0; attempt <= _maxRetries; attempt++)
        {
            Next(context);
            if ((int)context.Response.StatusCode < 500)
                break;
        }
    }
}
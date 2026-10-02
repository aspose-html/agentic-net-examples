// Add a custom handler that retries failed network requests up to three times before aborting.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

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

class Program
{
    static void Main()
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new RetryHandler(3));

            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1><img src=\"https://example.com/image.png\" /></body></html>";

            using (var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", configuration))
            {
                document.Save("output.html");
            }

            Console.WriteLine("Document saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Add a custom handler that retries failed network requests up to three times before aborting.

using System;

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
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new RetryHandler(3));

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
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
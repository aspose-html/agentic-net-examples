// Implement a retry mechanism when validating remote HTML content that may experience transient network failures.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class RetryHandler : MessageHandler
{
    private readonly int _maxRetries;
    public RetryHandler(int maxRetries)
    {
        _maxRetries = maxRetries;
    }
    public override void Invoke(INetworkOperationContext context)
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
            // Create configuration and add retry handler
            var configuration = new Configuration();
            var network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new RetryHandler(3));

            // Load remote HTML document with retry support
            string url = "https://example.com/page.html";
            using var document = new HTMLDocument(url, configuration);

            // Validate accessibility
            var webAccessibility = new WebAccessibility();
            var validator = webAccessibility.CreateValidator(ValidationBuilder.All);
            ValidationResult validationResult = validator.Validate(document);

            Console.WriteLine($"Validation success: {validationResult.Success}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
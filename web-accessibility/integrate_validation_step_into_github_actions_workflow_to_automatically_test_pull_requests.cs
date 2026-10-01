// Integrate the validation step into a GitHub Actions workflow to automatically test pull requests.

using System;
using System.Collections.Generic;
using System.Net;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Net;
using Aspose.Html.Services;

class AuthHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Simple auth check: require "Authorization" header
        if (string.IsNullOrEmpty(context.Request.Headers["Authorization"]))
        {
            context.Response.StatusCode = HttpStatusCode.Unauthorized;
            return;
        }
        Next(context);
    }
}

class LogHandler : Aspose.Html.Net.MessageHandler
{
    private readonly List<string> _logs = new List<string>();

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        _logs.Add($"URL: {context.Request.RequestUri} | Status: {context.Response.StatusCode}");
    }

    public IReadOnlyList<string> Logs => _logs;
}

class Program
{
    static void Main()
    {
        try
        {
            // Configuration with custom network handlers
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new AuthHandler());
            var logger = new LogHandler();
            network.MessageHandlers.Add(logger);

            // Sample HTML content
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <h1>Hello, Aspose.HTML!</h1>
    <p>This is a test document.</p>
</body>
</html>";

            // Load document using the configuration (handlers will be active)
            using (var document = new Aspose.Html.HTMLDocument(htmlContent, configuration))
            {
                // Accessibility validation (full set of rules)
                var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
                ValidationResult validationResult = validator.Validate(document);

                if (!validationResult.Success)
                {
                    Console.WriteLine("Accessibility validation failed. Details:");
                    foreach (RuleValidationResult detail in validationResult.Details)
                    {
                        Console.WriteLine($"Rule: {detail.Rule.Code} - {detail.Rule.Description} - Success: {detail.Success}");
                    }
                }
                else
                {
                    Console.WriteLine("Accessibility validation succeeded.");
                }

                // Guideline‑specific validation example
                var principle = webAccessibility.Rules.GetPrinciple("WCAG2.0");
                var guideline = principle.GetGuideline("1.1.1");
                var guidelineValidator = webAccessibility.CreateValidator(guideline, Aspose.Html.Accessibility.ValidationBuilder.All);
                ValidationResult guidelineResult = guidelineValidator.Validate(document);

                if (!guidelineResult.Success)
                {
                    Console.WriteLine("Guideline validation failed.");
                }
                else
                {
                    Console.WriteLine("Guideline validation succeeded.");
                }
            }

            // Output logged network activity
            Console.WriteLine("\nNetwork activity log:");
            foreach (string entry in logger.Logs)
            {
                Console.WriteLine(entry);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
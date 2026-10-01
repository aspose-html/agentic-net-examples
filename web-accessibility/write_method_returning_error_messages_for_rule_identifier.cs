// Write a method that returns a list of error messages for a specified rule identifier.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Drawing;

public sealed class NetworkLogger : Aspose.Html.Net.MessageHandler
{
    private readonly string _logFilePath;

    public NetworkLogger(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        using (StreamWriter writer = new StreamWriter(_logFilePath, true))
        {
            writer.WriteLine("Request URI: " + context.Request.RequestUri);
            writer.WriteLine("Request Headers: " + context.Request.Headers);
            Next(context);
            writer.WriteLine("Response Status: " + context.Response.StatusCode);
            writer.WriteLine("Response Headers: " + context.Response.Headers);
            writer.WriteLine(new string('-', 40));
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string inputPath = Path.Combine(Environment.CurrentDirectory, "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Output paths
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.html");
            string logPath = Path.Combine(Environment.CurrentDirectory, "network.log");

            // Create configuration and add network logger
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new NetworkLogger(logPath));

            // Load document with configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration))
            {
                // Save the document to verify loading works
                document.Save(outputPath);
            }

            // Accessibility validation - full validation
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (Aspose.Html.HTMLDocument docForValidation = new Aspose.Html.HTMLDocument(inputPath))
            {
                ValidationResult validationResult = validator.Validate(docForValidation);
                Console.WriteLine("=== Full Validation Results ===");
                foreach (RuleValidationResult detail in validationResult.Details)
                {
                    Console.WriteLine($"Rule: {detail.Rule.Code} - Success: {detail.Success}");
                }
            }

            // Accessibility validation - specific guideline
            Aspose.Html.Accessibility.Principle principle = webAccessibility.Rules.GetPrinciple("Perceivable");
            Aspose.Html.Accessibility.Guideline guideline = principle.GetGuideline("Text Alternatives");
            Aspose.Html.Accessibility.AccessibilityValidator guidelineValidator = webAccessibility.CreateValidator(guideline, Aspose.Html.Accessibility.ValidationBuilder.All);
            using (Aspose.Html.HTMLDocument docForGuideline = new Aspose.Html.HTMLDocument(inputPath))
            {
                ValidationResult guidelineResult = guidelineValidator.Validate(docForGuideline);
                Console.WriteLine("\n=== Guideline Validation Results ===");
                foreach (RuleValidationResult ruleResult in guidelineResult.Details)
                {
                    if (!ruleResult.Success)
                    {
                        Console.WriteLine($"Failed Rule: {ruleResult.Rule.Code} - {ruleResult.Rule.Description}");
                        foreach (ITechniqueResult techResult in ruleResult.Errors)
                        {
                            if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                            {
                                Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                Console.WriteLine($"  Element: <{element.TagName}> with outer HTML: {element.OuterHTML}");
                            }
                        }
                    }
                }
            }

            // Retrieve and display criterion details
            Aspose.Html.Accessibility.Criterion criterion = guideline.GetCriterion("1.1.1");
            if (criterion != null)
            {
                Console.WriteLine("\n=== Criterion Details ===");
                Console.WriteLine($"{criterion.Code}:{criterion.Description} - {criterion.Level}");
                foreach (Aspose.Html.Accessibility.IRule technique in criterion.SufficientTechniques)
                {
                    Console.WriteLine($"{technique.Code}:{technique.Description}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
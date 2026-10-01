// Exclude keyboard navigation warnings from the final report by applying a result‑filtering option.

using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.png' alt=''></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            string outputPath = "output.mhtml";

            // Accessibility validation
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (var document = new Aspose.Html.HTMLDocument(inputPath))
            {
                var validationResult = validator.Validate(document);
                if (!validationResult.Success)
                {
                    foreach (var ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (var techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    var element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    string attributeValue = element.GetAttribute("alt");
                                    Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                }
            }

            // Retrieve principle, guideline, and criterion information
            var principle = webAccessibility.Rules.GetPrinciple("1.1");
            if (principle != null)
            {
                var guideline = principle.GetGuideline("1.1.1");
                if (guideline != null)
                {
                    var criterion = guideline.GetCriterion("1.1.1.1");
                    if (criterion != null)
                    {
                        Console.WriteLine($"{criterion.Code}:{criterion.Description} - {criterion.Level}");
                        foreach (var technique in criterion.SufficientTechniques)
                        {
                            Console.WriteLine($"{technique.Code}:{technique.Description}");
                        }
                    }
                }
            }

            // Configure network service with custom message handler
            var configuration = new Aspose.Html.Configuration();
            var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new ExcludeUrlMessageHandler());

            // Load document via request (using file URI) and convert to MHTML
            string fileUri = new Uri(Path.GetFullPath(inputPath)).AbsoluteUri;
            var request = new Aspose.Html.Net.RequestMessage(fileUri);
            using (var document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                var options = new Aspose.Html.Saving.MHTMLSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Custom message handler to exclude specific URLs
class ExcludeUrlMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly Regex _excludeRegex = new Regex(@"\.png$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string urlText = context.Request.RequestUri.ToString();
        if (_excludeRegex.IsMatch(urlText))
        {
            return;
        }
        Next(context);
    }
}
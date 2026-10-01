// Detect and log any parsing warnings such as unknown tags or attributes during load.

using System;
using System.IO;
using System.Net;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><p id=\"para1\">Hello World</p></body></html>";

            // Create HTML document from string
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all <p> elements and print their tag names
            var elements = document.GetElementsByTagName("p");
            for (int i = 0; i < elements.Length; i++)
            {
                var element = (Aspose.Html.Dom.Element)elements[i];
                Console.WriteLine(element.TagName);
            }

            // Configure network service with a custom message handler
            var configuration = new Aspose.Html.Configuration();
            var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            var handlers = networkService.MessageHandlers;
            handlers.Insert(0, new TimeLoggerMessageHandler());

            // Prepare a temporary HTML file
            string dataDir = Path.GetTempPath();
            string documentPath = Path.Combine(dataDir, "sample.html");
            File.WriteAllText(documentPath, htmlContent);

            // Load document from file using the custom configuration
            var fileDocument = new Aspose.Html.HTMLDocument(documentPath, configuration);

            // Accessibility validation
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            using (var docForValidation = new Aspose.Html.HTMLDocument(documentPath))
            {
                var validationResult = validator.Validate(docForValidation);
                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    var element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    string attributeValue = element.GetAttribute("id");
                                    Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Accessibility validation succeeded with no errors.");
                }
            }

            // Additional simple validation example
            var simpleValidator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
            var simpleResult = simpleValidator.Validate(fileDocument);
            string resultContent = simpleResult.SaveToString();
            Console.WriteLine("Validation result saved to string (length: " + resultContent.Length + ").");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom message handler that logs request URI and response status
class TimeLoggerMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Console.WriteLine($"Request URI: {context.Request.RequestUri}, Status: {context.Response.StatusCode}");
        // Continue to the next handler in the pipeline
        Next(context);
    }
}
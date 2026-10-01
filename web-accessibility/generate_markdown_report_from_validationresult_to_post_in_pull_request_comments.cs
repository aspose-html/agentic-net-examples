// Generate a markdown report from ValidationResult to post directly in pull‑request comments.

using System;
using System.Collections.Generic;
using System.IO;

class HeaderCaptureHandler : Aspose.Html.Net.MessageHandler
{
    public static List<string> CapturedHeaders = new List<string>();

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Continue the request processing
        Next(context);

        // Capture response headers
        foreach (object headerItem in context.Response.Headers)
        {
            if (headerItem != null)
            {
                CapturedHeaders.Add(headerItem.ToString());
            }
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // -------------------- Network request with header capture --------------------
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new HeaderCaptureHandler());

            string url = "https://example.com";
            string outputHtmlPath = "output.html";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                if (HeaderCaptureHandler.CapturedHeaders.Count > 0)
                {
                    string commentText = "\n" + string.Join("\n", HeaderCaptureHandler.CapturedHeaders) + "\n";
                    var commentNode = document.CreateComment(commentText);
                    document.InsertBefore(commentNode, document.DocumentElement);
                }

                document.Save(outputHtmlPath);
                Console.WriteLine($"HTML saved to '{outputHtmlPath}'.");
            }

            // -------------------- Accessibility validation --------------------
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Validate the same HTML document loaded from the saved file
            using (Aspose.Html.HTMLDocument docForValidation = new Aspose.Html.HTMLDocument(outputHtmlPath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(docForValidation);
                if (!validationResult.Success)
                {
                    Console.WriteLine("Accessibility validation failed. Details:");
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                    {
                        Console.WriteLine($"- Rule: {detail.Rule.Code}, Description: {detail.Rule.Description}, Success: {detail.Success}");
                    }
                }
                else
                {
                    Console.WriteLine("Accessibility validation succeeded.");
                }
            }

            // -------------------- Markdown conversion (string source) --------------------
            string htmlContent = "<html><body><p>Hello World</p></body></html>";
            string markdownOutputPath1 = "output.md";

            Aspose.Html.Saving.MarkdownSaveOptions mdOptions1 = new Aspose.Html.Saving.MarkdownSaveOptions();
            mdOptions1.Features = Aspose.Html.Saving.MarkdownFeatures.Link | Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, mdOptions1, markdownOutputPath1);
            Console.WriteLine($"Markdown saved to '{markdownOutputPath1}' (from string).");

            // -------------------- Markdown conversion (file source) --------------------
            string htmlFilePath = "sample.html";
            string markdownOutputPath2 = "sample.md";

            // Ensure the sample HTML file exists
            if (!File.Exists(htmlFilePath))
            {
                File.WriteAllText(htmlFilePath, htmlContent);
            }

            Aspose.Html.Saving.MarkdownSaveOptions mdOptions2 = new Aspose.Html.Saving.MarkdownSaveOptions();
            mdOptions2.Features = Aspose.Html.Saving.MarkdownFeatures.Link | Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlFilePath, mdOptions2, markdownOutputPath2);
            Console.WriteLine($"Markdown saved to '{markdownOutputPath2}' (from file).");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
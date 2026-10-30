// Serialize the ValidationResult to JSON using custom serialization for external tool integration.

using System;
using System.Text.Json.Nodes;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";

            // Load HTML document from string
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                // Create accessibility validator with default rule set
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();

                // Perform validation
                ValidationResult validationResult = validator.Validate(document);

                // Build JSON representation
                JsonObject json = new JsonObject();
                json["Success"] = validationResult.Success;
                json["DetailCount"] = validationResult.Details.Count;

                // Output JSON string
                System.Console.WriteLine(json.ToJsonString());
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
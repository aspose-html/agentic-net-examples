// Filter validation results to display only audio‑description warnings for targeted video improvements.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file for validation
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.png'></body></html>";
            string inputPath = "sample.html";
            File.WriteAllText(inputPath, htmlContent);

            // Initialize WebAccessibility and validator
            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                ValidationResult validationResult = validator.Validate(document);
                if (!validationResult.Success)
                {
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == TargetTypes.HTMLElement)
                                {
                                    HTMLElement element = (HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    // Example attribute; adjust as needed based on the rule
                                    string attributeValue = element.GetAttribute("alt");
                                    Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Document passed accessibility validation.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
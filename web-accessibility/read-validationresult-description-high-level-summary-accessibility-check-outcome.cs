// Read ValidationResult.Description to obtain a high‑level summary of the accessibility check outcome.

using System;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html;
using Aspose.Html.IO;

namespace AsposeHtmlAccessibilityExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Sample HTML content
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><img src='image.png'></body></html>";

                // Initialize accessibility validator
                WebAccessibility webAccessibility = new WebAccessibility();
                AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

                // Load HTML document from inline content
                using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
                {
                    ValidationResult validationResult = validator.Validate(document);

                    // High‑level summary (fallback since Description property is unavailable)
                    if (validationResult.Success)
                    {
                        Console.WriteLine("Accessibility check passed.");
                    }
                    else
                    {
                        Console.WriteLine("Accessibility check failed.");
                    }

                    // Detailed error information
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
                                        string attributeValue = element.GetAttribute("alt");
                                        Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                    }
                                    else
                                    {
                                        Console.WriteLine(techResult.Error.ErrorMessage);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
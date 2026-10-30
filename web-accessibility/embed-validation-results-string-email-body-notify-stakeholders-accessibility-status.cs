// Embed validation results string into an email body to notify stakeholders of accessibility status.

using System;

namespace AccessibilityEmailExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Sample HTML content
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.png'></body></html>";

                // Create WebAccessibility and validator
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                // Load HTML from string (use two‑argument constructor)
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
                {
                    // Perform validation
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                    // Convert validation result to string
                    string resultString = validationResult.SaveToString();

                    // Build email body
                    string emailBody = $"Accessibility validation results:{Environment.NewLine}{resultString}";

                    // Output simulated email body
                    Console.WriteLine(emailBody);

                    // Optionally, list detailed errors
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
                                        Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                        string tagName = element.TagName;
                                        string altAttribute = element.GetAttribute("alt");
                                        Console.WriteLine($"Tag: {tagName}, Alt: {altAttribute}, Message: {techResult.Error.ErrorMessage}");
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
// Configure an AccessibilityValidator with custom settings before validating an HTML document in the application.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Initialize WebAccessibility
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Configure custom guideline (e.g., WCAG 2.0, guideline 2.4.1)
            Aspose.Html.Accessibility.Principle principle = webAccessibility.Rules.GetPrinciple("WCAG2.0");
            Aspose.Html.Accessibility.Guideline guideline = principle.GetGuideline("2.4.1");

            // Create validator with the custom guideline and all validation rules
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(guideline, Aspose.Html.Accessibility.ValidationBuilder.All);

            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.jpg'></body></html>";

            // Load HTML document from inline content (use two‑argument constructor)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Perform accessibility validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (validationResult.Success)
                {
                    Console.WriteLine("Accessibility validation passed.");
                }
                else
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                Console.WriteLine(techResult.Error.ErrorMessage);
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
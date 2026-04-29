// Load HTML content from a string, create a document object, and run accessibility validation.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.png'></body></html>";
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                WebAccessibility webAccessibility = new WebAccessibility();
                AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);
                ValidationResult validationResult = validator.Validate(document);
                if (validationResult.Success)
                {
                    Console.WriteLine("Accessibility validation passed.");
                }
                else
                {
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            Console.WriteLine($"Rule: {ruleResult.Rule.Code} - {ruleResult.Rule.Description}");
                            foreach (ITechniqueResult techResult in ruleResult.Errors)
                            {
                                Console.WriteLine($"Error: {techResult.Error.ErrorMessage}");
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}
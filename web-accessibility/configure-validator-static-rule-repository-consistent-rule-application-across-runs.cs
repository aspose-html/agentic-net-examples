// Configure the validator to use a static rule repository for consistent rule application across runs.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Initialize WebAccessibility
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Retrieve a specific guideline from the static rule repository
            var principle = webAccessibility.Rules.GetPrinciple("Perceivable");
            var guideline = principle.GetGuideline("TextAlternatives");

            // Create a validator using the selected guideline and all validation options
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(guideline, Aspose.Html.Accessibility.ValidationBuilder.All);

            // Sample HTML content (inline)
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><img src='image.png'></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Perform validation
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            // Process validation results
            if (!validationResult.Success)
            {
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                {
                    Console.WriteLine($"Rule Code: {detail.Rule.Code}");
                    Console.WriteLine($"Description: {detail.Rule.Description}");
                    Console.WriteLine($"Success: {detail.Success}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Validation succeeded with no issues.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
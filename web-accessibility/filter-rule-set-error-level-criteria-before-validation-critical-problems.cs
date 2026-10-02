// Filter the rule set to include only error‑level criteria before validation to focus on critical problems.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with an accessibility issue (image without alt text)
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='missing.jpg'></body></html>";

            // Load HTML document from inline content
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Initialize WebAccessibility and create a validator for all rules
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Perform validation
            var validationResult = validator.Validate(document);

            // Process only error‑level rule results
            if (!validationResult.Success)
            {
                foreach (var detail in validationResult.Details)
                {
                    if (!detail.Success)
                    {
                        Console.WriteLine($"{detail.Rule.Code}: {detail.Rule.Description}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No accessibility errors found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
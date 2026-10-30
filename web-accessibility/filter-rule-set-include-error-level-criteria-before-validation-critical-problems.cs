// Filter the rule set to include only error‑level criteria before validation to focus on critical problems.

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
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Sample</h1></body></html>";

            // Create HTMLDocument from inline content (use two-argument constructor)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Initialize WebAccessibility and create a validator with all rules
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Perform validation
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            // Process only error‑level (failed) rule results
            if (!validationResult.Success)
            {
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                {
                    if (!detail.Success) // focus on critical problems
                    {
                        Console.WriteLine("Rule Code: {0}", detail.Rule.Code);
                        Console.WriteLine("Description: {0}", detail.Rule.Description);
                        Console.WriteLine("Success: {0}", detail.Success);
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Document passed all accessibility checks.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
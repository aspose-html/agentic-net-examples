// Filter the rule set to include only error‑level criteria before validation to focus on critical problems.

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
            // Initialize the WebAccessibility engine
            WebAccessibility webAccessibility = new WebAccessibility();

            // Configure the validation builder to include only failure (error‑level) criteria
            ValidationBuilder builder = ValidationBuilder.All;
            builder.UseFailures();

            // Create a validator using the customized builder
            AccessibilityValidator validator = webAccessibility.CreateValidator(builder);

            // Load the HTML document to be validated
            HTMLDocument document = new HTMLDocument("sample.html");

            // Perform validation
            ValidationResult validationResult = validator.Validate(document);

            // Output details of rules that failed (error‑level)
            foreach (RuleValidationResult detail in validationResult.Details)
            {
                if (!detail.Success)
                {
                    Console.WriteLine($"{detail.Rule.Code}: {detail.Rule.Description} - Failed");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
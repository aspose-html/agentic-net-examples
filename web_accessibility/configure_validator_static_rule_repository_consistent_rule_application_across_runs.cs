// Configure the validator to use a static rule repository for consistent rule application across runs.

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
            var webAccessibility = new WebAccessibility();
            var validator = webAccessibility.CreateValidator(ValidationBuilder.All);
            var document = new HTMLDocument("https://example.com");
            var validationResult = validator.Validate(document);
            Console.WriteLine("Validation success: " + validationResult.Success);
            if (!validationResult.Success)
            {
                foreach (RuleValidationResult detail in validationResult.Details)
                {
                    Console.WriteLine($"{detail.Rule.Code}: {detail.Rule.Description} - Success: {detail.Success}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
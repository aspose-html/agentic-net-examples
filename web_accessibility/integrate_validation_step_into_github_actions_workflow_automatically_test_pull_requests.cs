// Integrate the validation step into a GitHub Actions workflow to automatically test pull requests.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static int Main(string[] args)
    {
        try
        {
            string url = args.Length > 0 ? args[0] : "https://example.com";
            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);
            HTMLDocument document = new HTMLDocument(url);
            ValidationResult validationResult = validator.Validate(document);
            if (!validationResult.Success)
            {
                foreach (RuleValidationResult detail in validationResult.Details)
                {
                    Console.WriteLine($"{detail.Rule.Code}: {detail.Rule.Description} - Success: {detail.Success}");
                }
                return 1;
            }
            Console.WriteLine("Accessibility validation passed.");
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            return 1;
        }
    }
}
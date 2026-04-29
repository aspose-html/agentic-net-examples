// Validate HTML documents retrieved from a remote URL by loading the URL content into the validator.

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
            string url = "https://example.com";
            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            HTMLDocument document = new HTMLDocument(url);
            ValidationResult validationResult = validator.Validate(document);
            if (!validationResult.Success)
            {
                foreach (RuleValidationResult detail in validationResult.Details)
                {
                    Console.WriteLine($"Rule: {detail.Rule.Code} - {detail.Rule.Description} Success: {detail.Success}");
                }
            }
            else
            {
                Console.WriteLine("Document passed accessibility validation.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
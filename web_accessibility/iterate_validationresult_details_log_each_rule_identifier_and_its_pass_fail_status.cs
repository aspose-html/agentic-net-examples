// Iterate through ValidationResult.Details to log each rule identifier and its pass or fail status.

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
            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator();
            HTMLDocument document = new HTMLDocument("sample.html");
            ValidationResult result = validator.Validate(document);

            foreach (RuleValidationResult detail in result.Details)
            {
                Console.WriteLine($"{detail.Rule.Code}: {(detail.Success ? "Pass" : "Fail")}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
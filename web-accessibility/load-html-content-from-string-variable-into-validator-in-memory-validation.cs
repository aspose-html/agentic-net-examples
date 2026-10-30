// Load HTML content from a string variable into the validator for in‑memory validation scenarios.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
            string baseUri = "about:blank";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
            {
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                System.Console.WriteLine("Validation Success: " + validationResult.Success);
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult rule in validationResult.Details)
                {
                    System.Console.WriteLine($"Rule: {rule.Rule.Code}");
                    foreach (Aspose.Html.Accessibility.IError error in rule.Errors)
                    {
                        System.Console.WriteLine($"Error: {error.ErrorMessage}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
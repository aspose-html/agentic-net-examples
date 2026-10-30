// Access ValidationResult.Warnings collection to count total accessibility warnings reported for the HTML page.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><img src='image.jpg'></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            int totalWarnings = 0;
            foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
            {
                if (ruleResult.Warnings != null)
                {
                    totalWarnings += ruleResult.Warnings.Count;
                }
            }

            System.Console.WriteLine($"Total accessibility warnings: {totalWarnings}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
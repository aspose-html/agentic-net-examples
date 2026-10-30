// Iterate through ValidationResult.Details to log each rule identifier and its pass or fail status.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Initialize WebAccessibility and create a validator for all rules
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";

            // Load HTML from string (use two‑argument constructor with a dummy base URI)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Perform accessibility validation
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            // Iterate through each rule result and log identifier with pass/fail status
            if (!validationResult.Success)
            {
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                {
                    string ruleId = detail.Rule != null ? detail.Rule.Code : "Unknown";
                    string status = detail.Success ? "Pass" : "Fail";
                    System.Console.WriteLine($"Rule: {ruleId}, Status: {status}");
                }
            }
            else
            {
                System.Console.WriteLine("All accessibility rules passed.");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
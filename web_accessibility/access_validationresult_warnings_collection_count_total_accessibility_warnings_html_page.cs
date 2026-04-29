// Access ValidationResult.Warnings collection to count total accessibility warnings reported for the HTML page.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the HTML file to be validated
            string htmlPath = "sample.html";

            // Initialize WebAccessibility and create a validator with all rules
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load the HTML document and perform validation
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                // Count total warnings across all rule results
                int warningCount = 0;
                foreach (var ruleResult in validationResult.Details)
                {
                    warningCount += ruleResult.Warnings.Count;
                }

                Console.WriteLine($"Total warnings: {warningCount}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
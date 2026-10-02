// Configure an AccessibilityValidator with custom settings before validating an HTML document in the application.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Initialize WebAccessibility
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Configure custom validation settings: select a specific principle and guideline
            Aspose.Html.Accessibility.Principle principle = webAccessibility.Rules.GetPrinciple("WCAG2AA");
            Aspose.Html.Accessibility.Guideline guideline = principle.GetGuideline("1.1.1");

            // Create validator with the selected guideline and all validation options
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(guideline, Aspose.Html.Accessibility.ValidationBuilder.All);

            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><img src=\"image.png\" alt=\"\"></body></html>";

            // Load HTML document from inline content
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (validationResult.Success)
                {
                    System.Console.WriteLine("Document is accessible.");
                }
                else
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                System.Console.WriteLine(techResult.Error.ErrorMessage);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
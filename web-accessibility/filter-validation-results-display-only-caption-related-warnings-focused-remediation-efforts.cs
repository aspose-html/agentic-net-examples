// Filter validation results to display only caption‑related warnings for focused remediation efforts.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content with a table missing a caption (to generate caption-related warnings)
            string htmlContent = "<html><body><table><tr><td>Data</td></tr></table></body></html>";

            // Load HTML document from string (using two-argument constructor)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create WebAccessibility instance and validator with all rules
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Perform validation
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            // Filter and display only caption-related warnings
            if (!validationResult.Success)
            {
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                {
                    if (!ruleResult.Success)
                    {
                        foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                        {
                            if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                            {
                                Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                string tagName = element.TagName;
                                string errorMessage = techResult.Error.ErrorMessage;

                                if (tagName.Equals("CAPTION", StringComparison.OrdinalIgnoreCase) ||
                                    errorMessage.IndexOf("caption", StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    Console.WriteLine($"Tag: {tagName}, Message: {errorMessage}");
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Filter validation results to display only audio‑description warnings for targeted video improvements.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with a video element (no audio description)
            string htmlContent = "<html><body><video src='sample.mp4'></video></body></html>";

            // Create a WebAccessibility instance
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Create a validator that runs all checks
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load the HTML document from the inline content
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                // If validation failed, process the details
                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                // Filter for audio‑description related warnings
                                if (techResult.Error.ErrorMessage != null &&
                                    techResult.Error.ErrorMessage.IndexOf("audio", StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                    {
                                        Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                        string tagName = element.TagName;
                                        string attributeValue = element.GetAttribute("src");
                                        System.Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("No accessibility issues detected.");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
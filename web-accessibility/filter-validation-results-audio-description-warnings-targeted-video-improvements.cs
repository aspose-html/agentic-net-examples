// Filter validation results to display only audio‑description warnings for targeted video improvements.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with a video element
            string htmlContent = "<html><body><video src='movie.mp4'></video></body></html>";
            // Create HTMLDocument from inline content
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Initialize WebAccessibility and validator
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            // Iterate over errors (or warnings if available) and filter for audio‑description messages
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    // Filter messages containing "audio description"
                                    if (techResult.Error.ErrorMessage != null &&
                                        techResult.Error.ErrorMessage.IndexOf("audio description", StringComparison.OrdinalIgnoreCase) >= 0)
                                    {
                                        Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                        string tagName = element.TagName;
                                        // Example attribute to display (e.g., "src")
                                        string attributeValue = element.GetAttribute("src");
                                        Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No accessibility issues detected.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
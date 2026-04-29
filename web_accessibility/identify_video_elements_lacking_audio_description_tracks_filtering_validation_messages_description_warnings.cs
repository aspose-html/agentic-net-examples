// Identify video elements lacking audio description tracks by filtering validation messages for description warnings.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Initialize the accessibility engine
            WebAccessibility webAccessibility = new WebAccessibility();

            // Create a validator that includes all accessibility checks
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            // Load the HTML document (replace with your actual file path or URL)
            using (HTMLDocument document = new HTMLDocument("input.html"))
            {
                // Perform validation
                ValidationResult validationResult = validator.Validate(document);

                // Process validation errors
                if (!validationResult.Success)
                {
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (ITechniqueResult techResult in ruleResult.Errors)
                            {
                                // Ensure the target is an HTML element
                                if (techResult.Error.Target.TargetType == TargetTypes.HTMLElement)
                                {
                                    HTMLElement element = (HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;

                                    // Identify <video> elements with description warnings
                                    if (tagName.Equals("video", StringComparison.OrdinalIgnoreCase) &&
                                        techResult.Error.ErrorMessage.Contains("description", StringComparison.OrdinalIgnoreCase))
                                    {
                                        // Retrieve a relevant attribute (e.g., src) for context
                                        string src = element.GetAttribute("src");
                                        Console.WriteLine($"Video src: {src}, Message: {techResult.Error.ErrorMessage}");
                                    }
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
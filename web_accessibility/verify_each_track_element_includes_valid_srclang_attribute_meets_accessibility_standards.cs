// Verify that each <track> element includes a valid srclang attribute to meet accessibility standards.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Initialize accessibility engine
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            // Create validator with all rules
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            // Load HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("sample.html"))
            {
                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
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
                                    // Process only <track> elements
                                    if (string.Equals(element.TagName, "track", StringComparison.OrdinalIgnoreCase))
                                    {
                                        string srclang = element.GetAttribute("srclang");
                                        if (string.IsNullOrEmpty(srclang))
                                        {
                                            Console.WriteLine($"Tag: {element.TagName}, Attribute: srclang, Message: {techResult.Error.ErrorMessage}");
                                        }
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
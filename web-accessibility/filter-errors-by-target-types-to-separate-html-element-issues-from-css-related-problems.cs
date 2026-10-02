// Filter errors by Target.TargetTypes to separate HTML element issues from CSS related problems.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src=\"image.png\" alt=\"\" /></body></html>";

            // Initialize WebAccessibility and validator
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load HTML document (using two-argument constructor to avoid file path issues)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
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
                                // Separate HTML element issues from CSS related problems
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    // Example: retrieve a common attribute; adjust as needed
                                    string attributeValue = element.GetAttribute("alt");
                                    Console.WriteLine($"HTML Element Issue - Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                                else
                                {
                                    // Treat all non-HTMLElement targets as CSS related issues
                                    Console.WriteLine($"CSS Issue - Message: {techResult.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Document passed all accessibility checks.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
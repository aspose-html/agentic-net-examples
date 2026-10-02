// Publish validation summaries to a dashboard for continuous monitoring of website accessibility status.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.jpg'></body></html>";
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                if (validationResult.Success)
                {
                    System.Console.WriteLine("Accessibility validation passed. No issues found.");
                }
                else
                {
                    System.Console.WriteLine("Accessibility validation failed. Summary:");
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
                                    string attributeValue = element.GetAttribute("alt");
                                    System.Console.WriteLine($"Tag: {tagName}, Attribute (alt): {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                                else
                                {
                                    System.Console.WriteLine($"Message: {techResult.Error.ErrorMessage}");
                                }
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
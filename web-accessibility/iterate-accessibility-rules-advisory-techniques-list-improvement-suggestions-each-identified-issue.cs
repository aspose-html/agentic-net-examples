// Iterate AccessibilityRules.AdvisoryTechniques to list improvement suggestions for each identified issue.

using System;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.jpg'></body></html>";
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
                {
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
                                        string tagName = element.TagName;
                                        string attributeValue = element.GetAttribute("alt");
                                        Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No accessibility issues found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
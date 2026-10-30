// Exclude keyboard navigation warnings from the final report by applying a result‑filtering option.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><a href=\"#\">Link</a></body></html>";
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            using (var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
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
                                    string attributeValue = element.GetAttribute("id");
                                    string message = techResult.Error.ErrorMessage;

                                    if (message != null && message.IndexOf("keyboard", StringComparison.OrdinalIgnoreCase) >= 0)
                                    {
                                        continue; // Exclude keyboard navigation warnings
                                    }

                                    System.Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {message}");
                                }
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("Accessibility validation succeeded with no issues.");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
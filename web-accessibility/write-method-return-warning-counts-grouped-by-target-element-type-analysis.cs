// Write a method that returns warning counts grouped by each target element type for analysis.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='missing.jpg' alt=''><a href=''>Link</a></body></html>";
            var warningCounts = GetWarningCountsByElement(htmlContent);
            foreach (var kvp in warningCounts)
            {
                Console.WriteLine($"Tag: {kvp.Key}, Warnings: {kvp.Value}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static Dictionary<string, int> GetWarningCountsByElement(string html)
    {
        var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
        var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
        using (var document = new Aspose.Html.HTMLDocument(html, "about:blank"))
        {
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
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
                            if (counts.ContainsKey(tagName))
                                counts[tagName]++;
                            else
                                counts[tagName] = 1;
                        }
                    }
                }
            }
        }
        return counts;
    }
}
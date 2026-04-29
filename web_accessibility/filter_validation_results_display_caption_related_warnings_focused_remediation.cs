// Filter validation results to display only caption‑related warnings for focused remediation efforts.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            if (!validationResult.Success)
            {
                foreach (RuleValidationResult ruleResult in validationResult.Details)
                {
                    foreach (ITechniqueResult techResult in ruleResult.Warnings)
                    {
                        if (techResult.Error.Target.TargetType == TargetTypes.HTMLElement)
                        {
                            HTMLElement element = (HTMLElement)techResult.Error.Target.Item;
                            if (string.Equals(element.TagName, "caption", StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine($"Caption Warning: {techResult.Error.ErrorMessage}");
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
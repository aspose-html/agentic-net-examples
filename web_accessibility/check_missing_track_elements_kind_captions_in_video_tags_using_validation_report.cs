// Check for missing <track> elements with kind="captions" in video tags using the validation report.

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
            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (HTMLDocument document = new HTMLDocument("input.html"))
            {
                ValidationResult validationResult = validator.Validate(document);
                if (!validationResult.Success)
                {
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == TargetTypes.HTMLElement)
                                {
                                    HTMLElement element = (HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    if (tagName.Equals("video", StringComparison.OrdinalIgnoreCase))
                                    {
                                        string src = element.GetAttribute("src");
                                        Console.WriteLine($"Video src: {src}, Message: {techResult.Error.ErrorMessage}");
                                    }
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
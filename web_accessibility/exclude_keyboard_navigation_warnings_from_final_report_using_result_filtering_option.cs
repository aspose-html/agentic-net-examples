// Exclude keyboard navigation warnings from the final report by applying a result‑filtering option.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility;

class Program
{
    static void Main()
    {
        try
        {
            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);
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
                                var error = techResult.Error;
                                if (error.ErrorMessage != null && error.ErrorMessage.IndexOf("keyboard", StringComparison.OrdinalIgnoreCase) >= 0)
                                    continue;
                                Console.WriteLine($"{ruleResult.Rule.Code}: {ruleResult.Rule.Description}");
                                Console.WriteLine(error.ErrorMessage);
                                if (error.Target.TargetType == TargetTypes.HTMLElement)
                                {
                                    HTMLElement element = (HTMLElement)error.Target.Item;
                                    Console.WriteLine(element.OuterHTML);
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Set a custom issue severity threshold so that only high‑priority accessibility problems are reported.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            using (HTMLDocument document = new HTMLDocument("<html><body><img src=''></body></html>"))
            {
                ValidationResult validationResult = validator.Validate(document);
                if (!validationResult.Success)
                {
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            Aspose.Html.Accessibility.Criterion criterion = ruleResult.Rule as Aspose.Html.Accessibility.Criterion;
                            if (criterion != null && criterion.Level == "AAA")
                            {
                                foreach (ITechniqueResult techResult in ruleResult.Errors)
                                {
                                    Console.WriteLine(techResult.Error.ErrorMessage);
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
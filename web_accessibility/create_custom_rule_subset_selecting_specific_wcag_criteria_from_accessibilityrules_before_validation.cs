// Create a custom rule subset by selecting specific WCAG criteria from AccessibilityRules before validation.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            Aspose.Html.Accessibility.Principle principle = webAccessibility.Rules.GetPrinciple("1");
            Aspose.Html.Accessibility.Guideline guideline = principle.GetGuideline("1.1");
            Aspose.Html.Accessibility.Criterion criterion = guideline.GetCriterion("1.1.1");

            if (criterion != null)
            {
                IList<Aspose.Html.Accessibility.IRule> selectedRules = new List<Aspose.Html.Accessibility.IRule> { criterion };
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(selectedRules);

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("sample.html"))
                {
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                    if (!validationResult.Success)
                    {
                        foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                        {
                            if (!detail.Success)
                            {
                                Console.WriteLine($"{detail.Rule.Code}: {detail.Rule.Description}");
                                foreach (Aspose.Html.Accessibility.ITechniqueResult tech in detail.Errors)
                                {
                                    Console.WriteLine($"  Error: {tech.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Document passed selected accessibility checks.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Specified criterion not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
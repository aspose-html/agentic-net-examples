// Create a validator instance using CreateValidator() before loading any HTML document for accessibility.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

namespace AccessibilityValidatorDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("sample.html"))
                {
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                    if (validationResult.Success)
                    {
                        Console.WriteLine("Document is accessible.");
                    }
                    else
                    {
                        foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                        {
                            if (!ruleResult.Success)
                            {
                                foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                                {
                                    Console.WriteLine(techResult.Error.ErrorMessage);
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
}
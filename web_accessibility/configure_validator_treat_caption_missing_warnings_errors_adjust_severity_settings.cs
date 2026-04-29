// Configure the validator to treat caption missing warnings as errors by adjusting severity settings.

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
            string htmlPath = "sample.html";
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                WebAccessibility webAccessibility = new WebAccessibility();
                AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);
                ValidationResult validationResult = validator.Validate(document);

                if (validationResult.Success)
                {
                    Console.WriteLine("Document passed accessibility validation.");
                }
                else
                {
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            Console.WriteLine($"Rule {ruleResult.Rule.Code}: {ruleResult.Rule.Description}");
                            foreach (ITechniqueResult techResult in ruleResult.Errors)
                            {
                                IError error = techResult.Error;
                                Console.WriteLine($"Error: {error.ErrorMessage}");
                                if (error.Target.TargetType == TargetTypes.HTMLElement)
                                {
                                    var element = (Aspose.Html.HTMLElement)error.Target.Item;
                                    Console.WriteLine($"Element: {element.OuterHTML}");
                                }
                            }
                            foreach (ITechniqueResult techResult in ruleResult.Warnings)
                            {
                                IError warning = techResult.Error;
                                Console.WriteLine($"Warning treated as error: {warning.ErrorMessage}");
                                if (warning.Target.TargetType == TargetTypes.HTMLElement)
                                {
                                    var element = (Aspose.Html.HTMLElement)warning.Target.Item;
                                    Console.WriteLine($"Element: {element.OuterHTML}");
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }
    }
}
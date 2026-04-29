// Filter errors by Target.TargetTypes to separate HTML element issues from CSS related problems.

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
            // Initialize accessibility services
            WebAccessibility webAccessibility = new WebAccessibility();

            // Create a validator that includes all rules
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

            // Load the HTML document (replace with your file path)
            using (HTMLDocument document = new HTMLDocument("input.html"))
            {
                // Perform validation
                ValidationResult validationResult = validator.Validate(document);

                if (!validationResult.Success)
                {
                    // Iterate over failed rules
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            // Iterate over each technique error
                            foreach (ITechniqueResult techResult in ruleResult.Errors)
                            {
                                var target = techResult.Error.Target;

                                // Separate handling based on target type
                                switch (target.TargetType)
                                {
                                    case TargetTypes.HTMLElement:
                                        var element = (HTMLElement)target.Item;
                                        Console.WriteLine($"HTML Element <{element.TagName}>: {techResult.Error.ErrorMessage}");
                                        break;

                                    case TargetTypes.CSSStyleRule:
                                        Console.WriteLine($"CSS Style Rule: {techResult.Error.ErrorMessage}");
                                        break;

                                    case TargetTypes.CSSStyleSheet:
                                        Console.WriteLine($"CSS Style Sheet: {techResult.Error.ErrorMessage}");
                                        break;

                                    default:
                                        Console.WriteLine($"Other Target: {techResult.Error.ErrorMessage}");
                                        break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Document passed accessibility validation.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
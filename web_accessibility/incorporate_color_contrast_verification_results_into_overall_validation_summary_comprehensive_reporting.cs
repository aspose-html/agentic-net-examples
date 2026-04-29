// Incorporate color contrast verification results into the overall validation summary for comprehensive reporting.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Dom;

namespace AccessibilityValidationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the HTML document to be validated
                using (HTMLDocument document = new HTMLDocument("input.html"))
                {
                    // Initialize WebAccessibility and create a validator with all rules
                    WebAccessibility webAccessibility = new WebAccessibility();
                    AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);

                    // Perform validation
                    ValidationResult validationResult = validator.Validate(document);

                    // Output overall validation status
                    Console.WriteLine($"Overall Validation Success: {validationResult.Success}");

                    // If there are validation errors, iterate through them
                    if (!validationResult.Success)
                    {
                        foreach (RuleValidationResult ruleResult in validationResult.Details)
                        {
                            if (!ruleResult.Success)
                            {
                                // Print rule identification
                                Console.WriteLine($"Rule: {ruleResult.Rule.Code} - {ruleResult.Rule.Description}");

                                // Iterate over each technique error within the rule
                                foreach (ITechniqueResult techResult in ruleResult.Errors)
                                {
                                    // Print the error message (includes color contrast messages)
                                    Console.WriteLine($"Message: {techResult.Error.ErrorMessage}");

                                    // If the error targets an HTML element, output element details
                                    if (techResult.Error.Target.TargetType == TargetTypes.HTMLElement)
                                    {
                                        HTMLElement element = (HTMLElement)techResult.Error.Target.Item;
                                        string tagName = element.TagName;
                                        string styleAttribute = element.GetAttribute("style");
                                        Console.WriteLine($"Element: <{tagName}>");
                                        Console.WriteLine($"Style Attribute: {styleAttribute}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
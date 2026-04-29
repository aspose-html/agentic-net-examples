// Compare two ValidationResult objects to detect regressions after modifying HTML content in the same project.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string originalPath = "original.html";
            string modifiedPath = "modified.html";

            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            Aspose.Html.HTMLDocument originalDoc = new Aspose.Html.HTMLDocument(originalPath);
            Aspose.Html.Accessibility.Results.ValidationResult originalResult = validator.Validate(originalDoc);

            Aspose.Html.HTMLDocument modifiedDoc = new Aspose.Html.HTMLDocument(modifiedPath);
            Aspose.Html.Accessibility.Results.ValidationResult modifiedResult = validator.Validate(modifiedDoc);

            var originalFailures = new System.Collections.Generic.HashSet<string>();
            if (!originalResult.Success)
            {
                foreach (RuleValidationResult ruleResult in originalResult.Details)
                {
                    if (!ruleResult.Success)
                    {
                        originalFailures.Add(ruleResult.Rule.Code);
                    }
                }
            }

            var modifiedFailures = new System.Collections.Generic.HashSet<string>();
            if (!modifiedResult.Success)
            {
                foreach (RuleValidationResult ruleResult in modifiedResult.Details)
                {
                    if (!ruleResult.Success)
                    {
                        modifiedFailures.Add(ruleResult.Rule.Code);
                    }
                }
            }

            bool regressionFound = false;
            foreach (var code in modifiedFailures)
            {
                if (!originalFailures.Contains(code))
                {
                    regressionFound = true;
                    Console.WriteLine($"Regression detected: Rule {code}");
                    foreach (RuleValidationResult ruleResult in modifiedResult.Details)
                    {
                        if (ruleResult.Rule.Code == code && !ruleResult.Success)
                        {
                            Console.WriteLine($"{ruleResult.Rule.Code} - {ruleResult.Rule.Description}");
                            foreach (ITechniqueResult techResult in ruleResult.Errors)
                            {
                                var error = techResult.Error;
                                Console.WriteLine(error.ErrorMessage);
                                if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                                    Console.WriteLine(element.OuterHTML);
                                }
                            }
                        }
                    }
                }
            }

            if (!regressionFound)
            {
                Console.WriteLine("No regressions detected.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
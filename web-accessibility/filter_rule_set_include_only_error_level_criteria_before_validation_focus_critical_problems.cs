// Filter the rule set to include only error‑level criteria before validation to focus on critical problems.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";

            // Create WebAccessibility instance
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

            // Create validator for all rules
            var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load document from string
            var document = new Aspose.Html.HTMLDocument(html);

            // Perform validation
            var validationResult = validator.Validate(document);

            // Output overall success
            Console.WriteLine("Validation Success: " + validationResult.Success);

            // Iterate rule results
            foreach (var detail in validationResult.Details)
            {
                Console.WriteLine($"Rule: {detail.Rule.Code} - {detail.Rule.Description} - Success: {detail.Success}");
                if (!detail.Success)
                {
                    foreach (var techResult in detail.Errors)
                    {
                        if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                        {
                            var element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                            Console.WriteLine($"  Element: <{element.TagName}>");
                        }
                    }
                }
            }

            // Example: retrieve a specific principle, guideline, and criterion
            var principle = webAccessibility.Rules.GetPrinciple("1.1");
            if (principle != null)
            {
                var guideline = principle.GetGuideline("1.1.1");
                if (guideline != null)
                {
                    var criterion = guideline.GetCriterion("1.1.1.1");
                    if (criterion != null)
                    {
                        Console.WriteLine($"{criterion.Code}:{criterion.Description} - Level {criterion.Level}");
                        foreach (var technique in criterion.SufficientTechniques)
                        {
                            Console.WriteLine($"{technique.Code}:{technique.Description}");
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
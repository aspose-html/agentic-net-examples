// Set a custom issue severity threshold so that only high‑priority accessibility problems are reported.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.png' alt=''></body></html>";

            // Load HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent))
            {
                // Create accessibility validator
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (validationResult.Success)
                {
                    System.Console.WriteLine("Document passed accessibility validation.");
                }
                else
                {
                    // Iterate over rule results
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            // Iterate over technique errors
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    string attributeValue = element.GetAttribute("alt");
                                    System.Console.WriteLine($"Tag: {tagName}, Attribute (alt): {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                                else
                                {
                                    System.Console.WriteLine($"Message: {techResult.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                }

                // Retrieve principle, guideline, and criterion information
                Aspose.Html.Accessibility.Principle principle = webAccessibility.Rules.GetPrinciple("Perceivable");
                if (principle != null)
                {
                    Aspose.Html.Accessibility.Guideline guideline = principle.GetGuideline("Text Alternatives");
                    if (guideline != null)
                    {
                        Aspose.Html.Accessibility.Criterion criterion = guideline.GetCriterion("1.1.1");
                        if (criterion != null)
                        {
                            System.Console.WriteLine($"{criterion.Code}:{criterion.Description} - {criterion.Level}");
                            foreach (Aspose.Html.Accessibility.IRule technique in criterion.SufficientTechniques)
                            {
                                System.Console.WriteLine($"{technique.Code}:{technique.Description}");
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
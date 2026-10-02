// Validate that every footnote definition is referenced somewhere in the document to avoid orphaned notes.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Example with footnote.<sup id=\"fnref1\"><a href=\"#fn1\">1</a></sup></p><section class=\"footnotes\"><ol><li id=\"fn1\">Footnote content.</li></ol></section></body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.Principle principle = webAccessibility.Rules.GetPrinciple("WCAG2.0");
                Aspose.Html.Accessibility.Guideline guideline = principle.GetGuideline("2.4.1");
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(guideline, Aspose.Html.Accessibility.ValidationBuilder.All);
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                {
                    if (!ruleResult.Success)
                    {
                        foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                        {
                            if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                            {
                                Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                Console.WriteLine($"Orphan footnote definition found: {element.OuterHTML}");
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
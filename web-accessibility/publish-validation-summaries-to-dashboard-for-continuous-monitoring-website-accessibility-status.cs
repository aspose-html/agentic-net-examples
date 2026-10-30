// Publish validation summaries to a dashboard for continuous monitoring of website accessibility status.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";

            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (validationResult.Success)
                {
                    System.Console.WriteLine("Accessibility validation succeeded. No issues found.");
                }
                else
                {
                    System.Console.WriteLine("Accessibility validation failed. Summary of issues:");
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    System.Console.WriteLine($"Tag: {tagName}, Message: {techResult.Error.ErrorMessage}");
                                }
                                else
                                {
                                    System.Console.WriteLine($"Message: {techResult.Error.ErrorMessage}");
                                }
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
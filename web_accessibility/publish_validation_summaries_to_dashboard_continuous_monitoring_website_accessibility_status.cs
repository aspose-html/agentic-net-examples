// Publish validation summaries to a dashboard for continuous monitoring of website accessibility status.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);
            using (HTMLDocument document = new HTMLDocument(url))
            {
                ValidationResult validationResult = validator.Validate(document);
                string summary = validationResult.SaveToString();
                Console.WriteLine("Accessibility Validation Summary:");
                Console.WriteLine(summary);
                if (!validationResult.Success)
                {
                    foreach (RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == TargetTypes.HTMLElement)
                                {
                                    HTMLElement element = (HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    string src = element.GetAttribute("src");
                                    Console.WriteLine($"Tag: {tagName}, Src: {src}, Message: {techResult.Error.ErrorMessage}");
                                }
                                else
                                {
                                    Console.WriteLine(techResult.Error.ErrorMessage);
                                }
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
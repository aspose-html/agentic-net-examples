// Filter validation results to display only caption‑related warnings for focused remediation efforts.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><table><tr><td>Data</td></tr></table></body></html>";
            string baseUri = "about:blank";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
            {
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (!validationResult.Success)
                {
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
                                    string message = techResult.Error.ErrorMessage;

                                    if (message != null && message.IndexOf("caption", StringComparison.OrdinalIgnoreCase) >= 0)
                                    {
                                        System.Console.WriteLine($"Tag: {tagName}, Message: {message}");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("No accessibility issues found.");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
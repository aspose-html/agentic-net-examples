// Generate a plain‑text summary of validation findings for quick review by developers.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='missing.jpg' alt=''></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
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
                            System.Console.WriteLine(ruleResult.Rule.Code + " - " + ruleResult.Rule.Description);
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                Aspose.Html.Accessibility.IError error = techResult.Error;
                                System.Console.WriteLine("Message: " + error.ErrorMessage);
                                if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                                    System.Console.WriteLine("Element: " + element.OuterHTML);
                                }
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("Validation succeeded. No issues found.");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
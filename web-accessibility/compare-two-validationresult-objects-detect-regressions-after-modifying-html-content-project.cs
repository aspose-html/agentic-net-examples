// Compare two ValidationResult objects to detect regressions after modifying HTML content in the same project.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Initialize WebAccessibility and validator for all rules
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Original HTML content (passes validation)
            string originalHtml = "<!DOCTYPE html><html><head><title>Original</title></head><body><img src='image.jpg' alt='sample'></body></html>";
            Aspose.Html.HTMLDocument originalDoc = new Aspose.Html.HTMLDocument(originalHtml, "about:blank");
            Aspose.Html.Accessibility.Results.ValidationResult originalResult = validator.Validate(originalDoc);

            // Modified HTML content (introduces a regression)
            string modifiedHtml = "<!DOCTYPE html><html><head><title>Modified</title></head><body><img src='image.jpg'></body></html>";
            Aspose.Html.HTMLDocument modifiedDoc = new Aspose.Html.HTMLDocument(modifiedHtml, "about:blank");
            Aspose.Html.Accessibility.Results.ValidationResult modifiedResult = validator.Validate(modifiedDoc);

            // Compare validation results
            if (originalResult.Success && modifiedResult.Success)
            {
                Console.WriteLine("No regressions detected. Both versions passed validation.");
            }
            else
            {
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult modRule in modifiedResult.Details)
                {
                    if (!modRule.Success)
                    {
                        bool originalSuccess = true;
                        foreach (Aspose.Html.Accessibility.Results.RuleValidationResult origRule in originalResult.Details)
                        {
                            if (origRule.Rule.Code == modRule.Rule.Code)
                            {
                                originalSuccess = origRule.Success;
                                break;
                            }
                        }

                        if (originalSuccess)
                        {
                            Console.WriteLine("Regression detected: Rule " + modRule.Rule.Code + " - " + modRule.Rule.Description);
                            foreach (Aspose.Html.Accessibility.ITechniqueResult tech in modRule.Errors)
                            {
                                Aspose.Html.Accessibility.IError error = tech.Error;
                                Console.WriteLine("  Error: " + error.ErrorMessage);
                                if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                                    Console.WriteLine("  Element: " + element.OuterHTML);
                                }
                            }
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
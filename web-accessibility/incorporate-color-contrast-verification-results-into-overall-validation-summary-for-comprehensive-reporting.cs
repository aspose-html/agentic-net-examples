// Incorporate color contrast verification results into the overall validation summary for comprehensive reporting.

using System;

namespace AsposeHtmlAccessibilityExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><p style='color:#777;'>Sample text</p></body></html>";
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
                {
                    Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                    Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                    // Overall validation summary
                    System.Console.WriteLine("Overall Validation Success: " + validationResult.Success);

                    // Detailed rule results
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        System.Console.WriteLine("Rule: " + ruleResult.Rule.Code + " - " + ruleResult.Rule.Description + " | Success: " + ruleResult.Success);
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                Aspose.Html.Accessibility.IError error = techResult.Error;
                                System.Console.WriteLine("  Error: " + error.ErrorMessage);
                                if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                                    System.Console.WriteLine("    Element: " + element.OuterHTML);
                                }
                            }
                        }
                    }

                    // Specific color contrast verification summary
                    bool colorContrastFound = false;
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (ruleResult.Rule.Code != null && ruleResult.Rule.Code.IndexOf("ColorContrast", System.StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            colorContrastFound = true;
                            System.Console.WriteLine("Color Contrast Verification - Success: " + ruleResult.Success);
                        }
                    }
                    if (!colorContrastFound)
                    {
                        System.Console.WriteLine("No specific Color Contrast rule found in validation results.");
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
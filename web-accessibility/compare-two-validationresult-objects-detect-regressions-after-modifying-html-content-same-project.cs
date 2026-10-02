// Compare two ValidationResult objects to detect regressions after modifying HTML content in the same project.

using System;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Original HTML content
                string originalHtml = "<!DOCTYPE html><html><head><title>Original</title></head><body><h1>Hello</h1></body></html>";
                // Modified HTML content (potential regression)
                string modifiedHtml = "<!DOCTYPE html><html><head><title>Modified</title></head><body><h1>Hello</h1><img src='missing.jpg'></body></html>";

                // Create WebAccessibility instance
                var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

                // Create a validator that checks all rules
                var validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                // Validate original HTML
                var documentOriginal = new Aspose.Html.HTMLDocument(originalHtml, "about:blank");
                Aspose.Html.Accessibility.Results.ValidationResult originalResult = validator.Validate(documentOriginal);

                // Validate modified HTML
                var documentModified = new Aspose.Html.HTMLDocument(modifiedHtml, "about:blank");
                Aspose.Html.Accessibility.Results.ValidationResult modifiedResult = validator.Validate(documentModified);

                // Compare validation results to detect regressions
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult originalRule in originalResult.Details)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult modifiedRule in modifiedResult.Details)
                    {
                        if (originalRule.Rule.Code == modifiedRule.Rule.Code)
                        {
                            // Regression: previously successful rule now fails
                            if (originalRule.Success && !modifiedRule.Success)
                            {
                                Console.WriteLine("Regression detected: " + modifiedRule.Rule.Code + " - " + modifiedRule.Rule.Description);
                                foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in modifiedRule.Errors)
                                {
                                    Aspose.Html.Accessibility.IError error = techResult.Error;
                                    Console.WriteLine("  Error: " + error.ErrorMessage);
                                    if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                    {
                                        Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                                        Console.WriteLine("  Element HTML: " + element.OuterHTML);
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
}
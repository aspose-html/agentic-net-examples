// Fail the build if any critical accessibility errors are detected to enforce quality gates.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                System.Console.WriteLine(techResult.Error.ErrorMessage);
                            }
                        }
                    }

                    // Fail the build due to critical accessibility errors
                    System.Environment.Exit(1);
                }
                else
                {
                    System.Console.WriteLine("Accessibility validation passed.");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine("Error: " + ex.Message);
            System.Environment.Exit(1);
        }
    }
}
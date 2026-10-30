// Fail the build if any critical accessibility errors are detected to enforce quality gates.

using System;

class Program
{
    static int Main()
    {
        try
        {
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img alt='sample'></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                bool hasErrors = false;
                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                System.Console.WriteLine(techResult.Error.ErrorMessage);
                                hasErrors = true;
                            }
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("Accessibility validation passed with no errors.");
                }

                return hasErrors ? 1 : 0;
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
            return 1;
        }
    }
}
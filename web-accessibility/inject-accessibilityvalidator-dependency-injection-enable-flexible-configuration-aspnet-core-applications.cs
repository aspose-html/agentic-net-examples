// Inject AccessibilityValidator via dependency injection to enable flexible configuration in ASP.NET Core applications.

using System;

class AccessibilityService
{
    private readonly Aspose.Html.Accessibility.AccessibilityValidator _validator;

    public AccessibilityService(Aspose.Html.Accessibility.AccessibilityValidator validator)
    {
        _validator = validator;
    }

    public void Validate(string htmlContent)
    {
        using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
        {
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = _validator.Validate(document);
            if (validationResult.Success)
            {
                System.Console.WriteLine("Accessibility validation succeeded.");
            }
            else
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
            }
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Sample</h1></body></html>";

            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            AccessibilityService service = new AccessibilityService(validator);
            service.Validate(html);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
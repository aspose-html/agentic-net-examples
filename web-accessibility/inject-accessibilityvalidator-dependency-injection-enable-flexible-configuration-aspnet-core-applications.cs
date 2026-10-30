// Inject AccessibilityValidator via dependency injection to enable flexible configuration in ASP.NET Core applications.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create WebAccessibility and validator
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Inject validator into service
            AccessibilityService service = new AccessibilityService(validator);

            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><img src=''></body></html>";

            // Perform validation
            service.ValidateHtml(htmlContent);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

class AccessibilityService
{
    private readonly Aspose.Html.Accessibility.AccessibilityValidator _validator;

    public AccessibilityService(Aspose.Html.Accessibility.AccessibilityValidator validator)
    {
        _validator = validator;
    }

    public void ValidateHtml(string htmlContent)
    {
        // Load HTML from string using two-argument constructor
        using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
        {
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = _validator.Validate(document);
            if (validationResult.Success)
            {
                Console.WriteLine("HTML passed accessibility validation.");
            }
            else
            {
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                {
                    if (!ruleResult.Success)
                    {
                        foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                        {
                            Console.WriteLine(techResult.Error.ErrorMessage);
                        }
                    }
                }
            }
        }
    }
}
// Validate generated HTML against W3C standards and report any compliance issues found.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='missing.jpg' alt=''></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            if (!validationResult.Success)
            {
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                {
                    if (!detail.Success)
                    {
                        System.Console.WriteLine(detail.Rule.Code + ": " + detail.Rule.Description);
                        foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in detail.Errors)
                        {
                            Aspose.Html.Accessibility.IError error = techResult.Error;
                            System.Console.WriteLine(error.ErrorMessage);
                            if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                            {
                                Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                                System.Console.WriteLine(element.OuterHTML);
                            }
                        }
                    }
                }
            }
            else
            {
                System.Console.WriteLine("HTML is compliant with W3C standards.");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
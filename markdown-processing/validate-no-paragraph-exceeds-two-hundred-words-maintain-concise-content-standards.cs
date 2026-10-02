// Validate that no paragraph exceeds two hundred words to maintain concise content standards.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
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
                System.Console.WriteLine("Accessibility validation succeeded with no errors.");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
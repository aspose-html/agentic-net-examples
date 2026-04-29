// Validate generated HTML against W3C standards and report any compliance issues found.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string separator = ": ";
            HTMLDocument document = new HTMLDocument(htmlPath);
            WebAccessibility webAccessibility = new WebAccessibility();
            AccessibilityValidator validator = webAccessibility.CreateValidator(ValidationBuilder.All);
            ValidationResult validationResult = validator.Validate(document);
            if (!validationResult.Success)
            {
                foreach (RuleValidationResult detail in validationResult.Details)
                {
                    if (!detail.Success)
                    {
                        Console.WriteLine(detail.Rule.Code + separator + detail.Rule.Description);
                        foreach (ITechniqueResult techResult in detail.Errors)
                        {
                            IError error = techResult.Error;
                            Console.WriteLine(error.ErrorMessage);
                            if (error.Target.TargetType == TargetTypes.HTMLElement)
                            {
                                HTMLElement element = (HTMLElement)error.Target.Item;
                                Console.WriteLine(element.OuterHTML);
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Document passed accessibility validation.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
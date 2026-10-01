// Validate the HTML structure against W3C standards and collect validation error messages.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='image.jpg'></body></html>";
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent))
                {
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
                        System.Console.WriteLine("HTML validation succeeded. No errors found.");
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
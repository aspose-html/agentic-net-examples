// Validate the HTML structure against W3C standards and collect validation error messages.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><title>Test</title></head><body><p>Paragraph without closing tag</body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
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
                            Console.WriteLine(detail.Rule.Code + ": " + detail.Rule.Description);
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in detail.Errors)
                            {
                                Aspose.Html.Accessibility.IError error = techResult.Error;
                                Console.WriteLine(error.ErrorMessage);
                                if (error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)error.Target.Item;
                                    Console.WriteLine(element.OuterHTML);
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("HTML validation succeeded with no errors.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Call ValidationResult.SaveToString to obtain a formatted string of errors and warnings.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                string formattedResult = validationResult.SaveToString();
                Console.WriteLine(formattedResult);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
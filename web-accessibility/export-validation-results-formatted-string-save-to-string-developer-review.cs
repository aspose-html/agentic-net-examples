// Export validation results as a formatted string using SaveToString for developer review.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
            string result = validationResult.SaveToString();
            System.Console.WriteLine("Validation Results:");
            System.Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Export validation results as a formatted string using SaveToString for developer review.

using System;

namespace AsposeHtmlAccessibilityExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
                {
                    Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                    string resultString = validationResult.SaveToString();
                    Console.WriteLine("Accessibility Validation Result:");
                    Console.WriteLine(resultString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
// Save the complete validation report to a string using ValidationResult.SaveToString method for later processing.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
                string baseUri = "about:blank";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
                Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                string report = validationResult.SaveToString();
                System.Console.WriteLine(report);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
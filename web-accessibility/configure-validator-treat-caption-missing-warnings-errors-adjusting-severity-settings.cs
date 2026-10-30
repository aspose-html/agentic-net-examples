// Configure the validator to treat caption missing warnings as errors by adjusting severity settings.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with a table missing a caption
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><table><tr><td>Cell</td></tr></table></body></html>";

            // Load HTML from inline content
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create accessibility validator with all default rules
            var webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            var builder = Aspose.Html.Accessibility.ValidationBuilder.All;
            // Note: Adjusting rule severity is not supported in this API version
            var validator = webAccessibility.CreateValidator(builder);

            // Validate the document
            var validationResult = validator.Validate(document);

            if (validationResult.Success)
            {
                Console.WriteLine("Validation succeeded with no errors.");
            }
            else
            {
                foreach (var ruleResult in validationResult.Details)
                {
                    if (!ruleResult.Success)
                    {
                        foreach (var techResult in ruleResult.Errors)
                        {
                            Console.WriteLine(techResult.Error.ErrorMessage);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
// Create a validator instance using CreateValidator() before loading any HTML document for accessibility.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";

            // Create WebAccessibility instance and validator before loading the document
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Load HTML document from inline content
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Perform accessibility validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                if (validationResult.Success)
                {
                    System.Console.WriteLine("Document is accessible.");
                }
                else
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                System.Console.WriteLine(techResult.Error.ErrorMessage);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}
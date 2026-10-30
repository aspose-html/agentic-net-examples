// Retrieve the ValidationResult returned by Validate and store it for further processing.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";

            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create WebAccessibility instance and validator
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            // Perform validation and store the result
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
            Aspose.Html.Accessibility.Results.ValidationResult storedResult = validationResult;

            // Process validation result
            if (!storedResult.Success)
            {
                Console.WriteLine("Validation failed. Details:");
                foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in storedResult.Details)
                {
                    Console.WriteLine($"Rule Code: {detail.Rule.Code}");
                    Console.WriteLine($"Description: {detail.Rule.Description}");
                    Console.WriteLine($"Success: {detail.Success}");
                    Console.WriteLine("---");
                }
            }
            else
            {
                Console.WriteLine("Validation succeeded with no errors.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Retrieve the ValidationResult returned by Validate and store it for further processing.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";
            string baseUri = "about:blank";

            // Load HTML document from string content
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
            {
                // Initialize WebAccessibility and create a validator for all rules
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                // Perform validation and store the result
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                // Process validation result
                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                    {
                        Console.WriteLine($"Rule Code: {detail.Rule.Code}");
                        Console.WriteLine($"Description: {detail.Rule.Description}");
                        Console.WriteLine($"Success: {detail.Success}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("HTML document passed all accessibility validation rules.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
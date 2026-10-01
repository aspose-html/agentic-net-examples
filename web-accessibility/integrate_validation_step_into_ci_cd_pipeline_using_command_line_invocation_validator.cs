// Integrate the validation step into a CI/CD pipeline using a command‑line invocation of the validator.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, world!</h1></body></html>";

            // Load the HTML document from the string
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent))
            {
                // Create a WebAccessibility instance
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();

                // Create a validator (default validation rules)
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator();

                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                // Save validation result as XML to a string and output it
                using (StringWriter sw = new StringWriter())
                {
                    validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                    Console.WriteLine("Validation Result (XML):");
                    Console.WriteLine(sw.ToString());
                }

                // Check success and output details if any failures
                if (!validationResult.Success)
                {
                    Console.WriteLine("Validation failed. Details:");
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
                    Console.WriteLine("Validation succeeded.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
// Serialize the ValidationResult to JSON using custom serialization for external tool integration.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the HTML file to be validated
            string htmlPath = "sample.html";

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                // Create an accessibility validator
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();

                // Perform validation
                ValidationResult validationResult = validator.Validate(document);

                // Serialize the validation result to JSON
                using (StringWriter writer = new StringWriter())
                {
                    validationResult.SaveTo(writer, ValidationResultSaveFormat.JSON);
                    string json = writer.ToString();
                    Console.WriteLine(json);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}
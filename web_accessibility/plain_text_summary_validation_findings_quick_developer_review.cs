// Generate a plain‑text summary of validation findings for quick review by developers.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

namespace AccessibilityValidationApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string filePath = "sample.html";
                HTMLDocument document = new HTMLDocument(filePath);
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();
                ValidationResult validationResult = validator.Validate(document);
                string summary = validationResult.SaveToString();
                Console.WriteLine(summary);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
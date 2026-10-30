// Write validation results to an XML file by calling ValidationResult.SaveTo with Xml format.

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
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                WebAccessibility webAccessibility = new WebAccessibility();
                AccessibilityValidator validator = webAccessibility.CreateValidator();
                ValidationResult validationResult = validator.Validate(document);

                string outputPath = "validation_result.xml";
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    validationResult.SaveTo(writer, ValidationResultSaveFormat.XML);
                }

                Console.WriteLine($"Validation results saved to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
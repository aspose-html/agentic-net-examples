// Save validation results to an XML file for compatibility with legacy systems and workflows.

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
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
            // Create HTML document from inline content
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                // Create accessibility validator
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();
                // Perform validation
                ValidationResult validationResult = validator.Validate(document);
                // Save validation result to XML file
                string outputPath = "validation_result.xml";
                using (StringWriter sw = new StringWriter())
                {
                    validationResult.SaveTo(sw, ValidationResultSaveFormat.XML);
                    File.WriteAllText(outputPath, sw.ToString());
                }
                Console.WriteLine($"Validation results saved to: {Path.GetFullPath(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
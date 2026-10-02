// Write the formatted validation string to a text file for archival and reporting.

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

            // Load HTML document from inline content
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                // Create accessibility validator
                WebAccessibility webAccessibility = new WebAccessibility();
                AccessibilityValidator validator = webAccessibility.CreateValidator();

                // Perform validation
                ValidationResult validationResult = validator.Validate(document);

                // Save validation result to XML string
                string xmlResult;
                using (StringWriter sw = new StringWriter())
                {
                    validationResult.SaveTo(sw, ValidationResultSaveFormat.XML);
                    xmlResult = sw.ToString();
                }

                // Write XML string to file
                string outputPath = "validation_report.xml";
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.Write(xmlResult);
                }

                Console.WriteLine("Validation report saved to: " + Path.GetFullPath(outputPath));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Serialize the ValidationResult to XML using custom serialization for legacy system compatibility.

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
            // Prepare a minimal HTML file
            string inputPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                // Create validator and perform validation
                Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                // Serialize validation result to XML
                using (StringWriter sw = new StringWriter())
                {
                    validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                    string xml = sw.ToString();

                    // Save XML to file (custom serialization for legacy system)
                    string outputPath = "validation_result.xml";
                    File.WriteAllText(outputPath, xml);
                    Console.WriteLine("Validation result saved to: " + outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
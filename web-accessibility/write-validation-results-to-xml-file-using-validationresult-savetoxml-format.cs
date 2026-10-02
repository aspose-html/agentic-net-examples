// Write validation results to an XML file by calling ValidationResult.SaveTo with Xml format.

using System;
using System.IO;

namespace AsposeHtmlAccessibilityExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
                {
                    Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                    string outputPath = "validation_result.xml";
                    using (StreamWriter writer = new StreamWriter(outputPath))
                    {
                        validationResult.SaveTo(writer, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                    }

                    Console.WriteLine($"Validation results saved to '{outputPath}'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
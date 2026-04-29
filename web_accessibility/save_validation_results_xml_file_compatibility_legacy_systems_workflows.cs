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
            string inputPath = "input.html";
            string outputPath = "validation_results.xml";

            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();
                ValidationResult validationResult = validator.Validate(document);

                using (StringWriter sw = new StringWriter())
                {
                    validationResult.SaveTo(sw, ValidationResultSaveFormat.XML);
                    string xml = sw.ToString();
                    File.WriteAllText(outputPath, xml);
                }
            }

            Console.WriteLine("Validation results saved to XML successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
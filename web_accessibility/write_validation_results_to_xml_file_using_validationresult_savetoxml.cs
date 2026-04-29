// Write validation results to an XML file by calling ValidationResult.SaveTo with Xml format.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;

namespace HtmlAccessibilityValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Expect input HTML path and output XML path
                if (args.Length < 2)
                {
                    Console.WriteLine("Usage: HtmlAccessibilityValidation <input.html> <output.xml>");
                    return;
                }

                string htmlPath = args[0];
                string xmlPath = args[1];

                // Load HTML document
                using (HTMLDocument document = new HTMLDocument(htmlPath))
                {
                    // Create validator
                    AccessibilityValidator validator = new WebAccessibility().CreateValidator();

                    // Perform validation
                    ValidationResult validationResult = validator.Validate(document);

                    // Save result to XML string
                    using (StringWriter sw = new StringWriter())
                    {
                        validationResult.SaveTo(sw, ValidationResultSaveFormat.XML);
                        string xmlContent = sw.ToString();

                        // Write XML to file
                        File.WriteAllText(xmlPath, xmlContent);
                    }
                }

                Console.WriteLine("Validation completed. XML saved to " + xmlPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
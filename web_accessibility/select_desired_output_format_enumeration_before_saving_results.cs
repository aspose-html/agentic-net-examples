// Select the desired output format by using the ValidationResultSaveFormat enumeration before saving results.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;

namespace HtmlAccessibilityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the HTML file to be validated
                string inputPath = "sample.html";

                // Load the HTML document
                using (HTMLDocument document = new HTMLDocument(inputPath))
                {
                    // Create the accessibility validator
                    AccessibilityValidator validator = new WebAccessibility().CreateValidator();

                    // Perform validation
                    ValidationResult validationResult = validator.Validate(document);

                    // Save validation result as XML using the enum to specify format
                    using (StringWriter writer = new StringWriter())
                    {
                        validationResult.SaveTo(writer, ValidationResultSaveFormat.XML);
                        Console.WriteLine(writer.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
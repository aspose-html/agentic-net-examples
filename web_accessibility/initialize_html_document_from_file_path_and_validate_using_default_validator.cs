// Initialize an HTMLDocument from a file path and validate it using the default validator.

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
                string filePath = "input.html";

                // Load the HTML document from the specified file
                using (HTMLDocument document = new HTMLDocument(filePath))
                {
                    // Create the default accessibility validator
                    AccessibilityValidator validator = new WebAccessibility().CreateValidator();

                    // Perform validation
                    ValidationResult validationResult = validator.Validate(document);

                    // Write validation results as XML to a string
                    using (StringWriter sw = new StringWriter())
                    {
                        validationResult.SaveTo(sw, ValidationResultSaveFormat.XML);
                        Console.WriteLine(sw.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur during processing
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
// Serialize the ValidationResult to XML using custom serialization for legacy system compatibility.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html.Accessibility.Saving;

namespace AccessibilitySerializationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the HTML file to be validated
                string htmlFilePath = "sample.html";

                // Load the HTML document
                using (HTMLDocument document = new HTMLDocument(htmlFilePath))
                {
                    // Create the accessibility validator
                    AccessibilityValidator validator = new WebAccessibility().CreateValidator();

                    // Perform validation
                    ValidationResult validationResult = validator.Validate(document);

                    // Serialize the validation result to XML
                    using (StringWriter stringWriter = new StringWriter())
                    {
                        validationResult.SaveTo(stringWriter, ValidationResultSaveFormat.XML);
                        string xmlOutput = stringWriter.ToString();

                        // Output the XML string (could be saved to a file or sent to a legacy system)
                        Console.WriteLine(xmlOutput);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
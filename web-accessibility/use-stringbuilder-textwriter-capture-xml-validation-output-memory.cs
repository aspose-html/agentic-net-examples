// Use a StringBuilder with a TextWriter to capture XML validation output in memory.

using System;
using System.Text;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";

            // Load HTML document from string
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Create accessibility validator
                Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();

                // Perform validation
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                // Capture XML validation output in memory
                StringBuilder sb = new StringBuilder();
                using (StringWriter sw = new StringWriter(sb))
                {
                    validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                }

                // Output the captured XML
                Console.WriteLine("Accessibility Validation Result (XML):");
                Console.WriteLine(sb.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
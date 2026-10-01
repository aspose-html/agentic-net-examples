// Initialize an HTMLDocument from a file path and validate it using the default validator.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1><p>This is a sample.</p></body></html>";

            // Load HTML document from string
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, ""))
            {
                // Perform accessibility validation
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator();
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                // Save validation result to XML string and output
                using (StringWriter sw = new StringWriter())
                {
                    validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                    string xmlResult = sw.ToString();
                    Console.WriteLine("Accessibility Validation Result (XML):");
                    Console.WriteLine(xmlResult);
                }

                // Output the document's outer HTML
                string outerHtml = document.DocumentElement.OuterHTML;
                Console.WriteLine("\nDocument OuterHTML:");
                Console.WriteLine(outerHtml);

                // Output the body text content
                Aspose.Html.HTMLElement body = document.Body;
                string bodyText = body.TextContent;
                Console.WriteLine("\nBody TextContent:");
                Console.WriteLine(bodyText);

                // Save the document to a file
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"\nDocument saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
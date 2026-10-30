// Load an HTML file from disk into the validator using the Load method with a file path argument.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";

            if (!File.Exists(inputPath))
            {
                string sampleContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello</p></body></html>";
                File.WriteAllText(inputPath, sampleContent);
            }

            // Load HTML document from file
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create validator
            var validator = new WebAccessibility().CreateValidator();

            // Validate the document
            ValidationResult result = validator.Validate(document);

            Console.WriteLine("Validation Success: " + result.Success);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Initialize an HTMLDocument from a file path and validate it using the default validator.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello World</p></body></html>");
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Accessibility.AccessibilityValidator validator =
                    new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();

                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                string resultXml = validationResult.SaveToString();

                Console.WriteLine("Validation result (XML):");
                Console.WriteLine(resultXml);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
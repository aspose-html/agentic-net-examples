// Load an HTML file from disk into the validator using the Load method with a file path argument.

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
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            Aspose.Html.Accessibility.WebAccessibility webAcc = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAcc.CreateValidator();

            Aspose.Html.Accessibility.Results.ValidationResult result = validator.Validate(document);

            Console.WriteLine("Validation success: " + result.Success);
            Console.WriteLine("Number of rule results: " + result.Details.Count);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
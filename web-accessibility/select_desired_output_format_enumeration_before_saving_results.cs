// Select the desired output format by using the ValidationResultSaveFormat enumeration before saving results.

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
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>");
            }

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();
                ValidationResult validationResult = validator.Validate(document);
                using (StringWriter sw = new StringWriter())
                {
                    validationResult.SaveTo(sw, ValidationResultSaveFormat.XML);
                    string xml = sw.ToString();
                    Console.WriteLine(xml);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
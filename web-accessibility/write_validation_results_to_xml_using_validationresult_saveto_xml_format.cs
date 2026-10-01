// Write validation results to an XML file by calling ValidationResult.SaveTo with Xml format.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file to validate
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>";
            string inputPath = "sample.html";
            File.WriteAllText(inputPath, htmlContent);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                using (StringWriter sw = new StringWriter())
                {
                    validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                    Console.WriteLine("Accessibility validation result (XML):");
                    Console.WriteLine(sw.ToString());
                }
            }

            // Clean up the temporary file
            if (File.Exists(inputPath))
            {
                File.Delete(inputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
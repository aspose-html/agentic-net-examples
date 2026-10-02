// Create a PowerShell script that loads the .NET library, validates an HTML file, and prints JSON results.

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
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, World!</h1></body></html>");
            }

            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                using (System.IO.StringWriter sw = new System.IO.StringWriter())
                {
                    validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.JSON);
                    string json = sw.ToString();
                    Console.WriteLine(json);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
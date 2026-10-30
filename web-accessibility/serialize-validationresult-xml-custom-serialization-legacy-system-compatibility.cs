// Serialize the ValidationResult to XML using custom serialization for legacy system compatibility.

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
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator();
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                using (System.IO.StringWriter sw = new System.IO.StringWriter())
                {
                    validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                    string xml = sw.ToString();
                    Console.WriteLine(xml);
                    System.IO.File.WriteAllText("validation_result.xml", xml);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
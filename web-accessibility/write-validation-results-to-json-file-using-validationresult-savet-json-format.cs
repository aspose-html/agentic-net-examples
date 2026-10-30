// Write validation results to a JSON file by calling ValidationResult.SaveTo with Json format.

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
            string baseUri = "about:blank";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
            {
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator();
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                string jsonPath = "validationResult.json";
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(jsonPath))
                {
                    validationResult.SaveTo(writer, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.JSON);
                }
            }

            Console.WriteLine("Validation results saved to JSON file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
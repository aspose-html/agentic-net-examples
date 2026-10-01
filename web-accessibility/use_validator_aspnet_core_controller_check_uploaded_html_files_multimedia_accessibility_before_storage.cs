// Use the validator in an ASP.NET Core controller to check uploaded HTML files for multimedia accessibility before storage.

using System;
using System.IO;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello</p></body></html>";
            File.WriteAllText(inputPath, htmlContent);
            string url = new Uri(Path.GetFullPath(inputPath)).AbsoluteUri;

            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.Guideline guideline = webAccessibility.Rules.GetPrinciple("Perceivable").GetGuideline("TimeBasedMedia");
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(guideline, Aspose.Html.Accessibility.ValidationBuilder.All);
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);
            Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

            if (!validationResult.Success)
            {
                Console.WriteLine("Accessibility validation failed.");
            }
            else
            {
                Console.WriteLine("Accessibility validation succeeded.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
// Call ValidationResult.SaveToString to obtain a formatted string of errors and warnings.

using System;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            HTMLDocument document = new HTMLDocument(htmlPath);
            AccessibilityValidator validator = new WebAccessibility().CreateValidator();
            ValidationResult validationResult = validator.Validate(document);
            string resultString = validationResult.SaveToString();
            Console.WriteLine(resultString);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
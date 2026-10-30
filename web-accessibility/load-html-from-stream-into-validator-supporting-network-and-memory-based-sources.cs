// Load HTML from a Stream object into the validator to support network or memory‑based sources.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Accessibility;
using Aspose.Html.Accessibility.Results;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello World</p></body></html>";
            byte[] htmlBytes = Encoding.UTF8.GetBytes(html);
            using (MemoryStream htmlStream = new MemoryStream(htmlBytes))
            {
                HTMLDocument document = new HTMLDocument(htmlStream, "about:blank");
                WebAccessibility webAccessibility = new WebAccessibility();
                var validator = webAccessibility.CreateValidator();
                ValidationResult validationResult = validator.Validate(document);
                Console.WriteLine("Validation Success: " + validationResult.Success);
                string resultString = validationResult.SaveToString();
                Console.WriteLine(resultString);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
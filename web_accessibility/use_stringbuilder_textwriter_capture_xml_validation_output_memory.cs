// Use a StringBuilder with a TextWriter to capture XML validation output in memory.

using System;
using System.Text;
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
            string htmlPath = "sample.html";
            var sb = new StringBuilder();
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                AccessibilityValidator validator = new WebAccessibility().CreateValidator();
                ValidationResult validationResult = validator.Validate(document);
                using (StringWriter sw = new StringWriter(sb))
                {
                    validationResult.SaveTo(sw, ValidationResultSaveFormat.XML);
                }
            }
            string xmlOutput = sb.ToString();
            Console.WriteLine(xmlOutput);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}